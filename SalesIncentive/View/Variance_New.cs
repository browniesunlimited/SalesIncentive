using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using SalesIncentive.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesIncentive.View
{
    public partial class Variance_New : Form
    {
        private string username = String.Empty;
        public Variance_New(string _username)
        {
            InitializeComponent();
            dateTimePicker.Value = DateTime.Now;
            username = _username;
        }

        private DataTable variances, dtOutlets;
        string date = String.Empty, table;

        private int GatherCurrentSalesIncentives()
        {
            string month = dateTimePicker.Value.Month.ToString();
            string year = dateTimePicker.Value.ToString("yyyy");

            string query = $@"SELECT
                                sales.OutletNo AS OUTLET_NO,
                                outlet.OUTLET_NAME,
                                sales.Amount AS VARIANCE,
                                sales.Spoilage AS SPOILAGE
                            FROM {table} sales
                            LEFT JOIN M_OUTLET_SALES_INCENTIVES outlet 
                                ON sales.OutletNo = outlet.OUTLET_NO
                            WHERE sales.DateMonth = @Month AND sales.DateYear = @Year
                            ORDER BY outlet.OUTLET_NAME ASC;";

            SqlParameter[] param =
            {
                new SqlParameter("@Month", month),
                new SqlParameter("@Year", year)
            };

            using (var reader = SQL.ExecuteSQLDataReader(query, param))
            {
                dgvVariance.DataSource = null;

                if (reader.HasRows)
                {
                    DataTable dtVariances = new DataTable();
                    dtVariances.Load(reader);
                    dgvVariance.DataSource = dtVariances;
                    return 1;
                }
                return 0;
            }
        }
        private void GatherOutlets()
        {
            string query = @"SELECT
                         OUTLET_NO,
                         OUTLET_NAME,
                         CAST('0' AS DECIMAL(18, 2)) AS VARIANCE,
                         CAST('0' AS DECIMAL(18, 2)) AS SPOILAGE
                     FROM M_OUTLET_SALES_INCENTIVES
                     ORDER BY OUTLET_NAME";

            SqlParameter param = new SqlParameter("@Val", "0");

            using (var reader = SQL.ExecuteSQLDataReader(query, param))
            {
                if (reader.HasRows)
                {
                    dtOutlets = new DataTable();
                    dtOutlets.Load(reader);

                    dgvVariance.DataSource = dtOutlets;
                }
            }
        }

        private void dateTimePicker_CloseUp(object sender, EventArgs e)
        {
            date = dateTimePicker.Value.ToString("MMMM yyyy");
            label2.Text = $"Outlet Variance for {date}";

            //Check for temp table first
            table = "TEMP_SalesIncentiveVariance";
            int hasTempRows = GatherCurrentSalesIncentives();
            btnSave.Text = "Final Save";

            if (hasTempRows == 0)
            {
                //Check for final table
                table = "SalesIncentiveVariance";
                int hasRows = GatherCurrentSalesIncentives();

                //Means no rows existed on 2 tables
                if (hasRows == 0)
                {
                    table = "TEMP_SalesIncentiveVariance";
                    GatherOutlets();
                    btnSave.Text = "Pre-Save";
                }
            }

            BtnUpload.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            date = dateTimePicker.Value.ToString("MMMM yyyy");
            ofdFile.Title = $"Upload Sales Variance Report for {date}";

            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                DataTable dataTable = new DataTable();

                try
                {
                    var desiredColumns = new[] { "OUTLET_NO", "OUTLET_NAME", "SPOILAGE", "VARIANCE" };

                    using (XLWorkbook workbook = new XLWorkbook(ofdFile.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);

                        var headerRow = worksheet.Row(1);
                        var columnIndexes = headerRow.Cells()
                                                     .Select((cell, index) => new { cell, index })
                                                     .Where(x => desiredColumns.Contains(x.cell.Value.ToString()))
                                                     .ToDictionary(x => x.cell.Value.ToString(), x => x.index + 1);

                        foreach (var colName in desiredColumns)
                        {
                            if (columnIndexes.ContainsKey(colName))
                                dataTable.Columns.Add(colName);
                        }

                        foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                        {
                            DataRow dataRow = dataTable.NewRow();
                            foreach (var colName in desiredColumns)
                            {
                                if (columnIndexes.ContainsKey(colName))
                                {
                                    int colIndex = columnIndexes[colName];
                                    dataRow[colName] = row.Cell(colIndex).Value;
                                }
                            }
                            dataTable.Rows.Add(dataRow);
                        }
                    }

                    dgvVariance.DataSource = dataTable;

                    Cursor.Current = Cursors.Default;
                }
                catch (IOException ex)
                {
                    MessageBox.Show(this, ex.Message, "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void RemoveToOverWrite(string month, string year)
        {
            string deleteCurrent = $@"DELETE FROM {table}
                                     WHERE DateMonth = @Month AND DateYear = @Year; ";

            //Add this to Execution, as it doesn't delete the temp table if the final save is executed
            if (btnSave.Text.Equals("Save-Final")) 
            {
                deleteCurrent += $@"DELETE FROM TEMP_SalesIncentives
                                     WHERE DateMonth = @Month AND DateYear = @Year;";
            }

            SqlParameter[] parameters =
            {
                new SqlParameter("@Month", month),
                new SqlParameter("@Year", year)
            };
            SQL.ExecuteNonQuery(deleteCurrent, parameters);
        }
        private void InsertDataToDB(string month, string year)
        {
            int insertedRows = 0;
            foreach (DataGridViewRow row in dgvVariance.Rows)
            {
                if (row.IsNewRow) continue;

                var outletNo = row.Cells[0].Value;
                var outletName = row.Cells[1].Value;

                decimal spoilage = 0;
                decimal variance = 0;

                if (decimal.TryParse(Convert.ToString(row.Cells[2].Value), out decimal parsedVariance))
                    variance = parsedVariance;

                if (decimal.TryParse(Convert.ToString(row.Cells[3].Value), out decimal parsedSpoilage))
                    spoilage = parsedSpoilage;

                string query = $@"INSERT INTO {table} (
                                    OutletNo, Spoilage,
                                    ModifiedBy, ModifiedDate,
                                    DateMonth, DateYear,
                                    Amount )
                                 VALUES (
                                    @OutletNo, @Spoilage,
                                    @ModBy, @ModDate,
                                    @Month, @Year,
                                    @Variance );";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@OutletNo", outletNo),
                    new SqlParameter("@OutletName", outletName),
                    new SqlParameter("@Month", month),
                    new SqlParameter("@Year", year),
                    new SqlParameter("@ModBy", username),
                    new SqlParameter("@ModDate", DateTime.Now.ToString()),
                    new SqlParameter("@Spoilage", variance),
                    new SqlParameter("@Variance", spoilage)
                };

                SQL.ExecuteNonQuery(query, parameters);
                insertedRows++;
            }

            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(this, $"{insertedRows} rows affected.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            string btnText = btnSave.Text;
            table = btnText.Equals("Pre-Save") ? "TEMP_SalesIncentiveVariance" : "SalesIncentiveVariance";

            string month = dateTimePicker.Value.Month.ToString();
            string monthStr = dateTimePicker.Value.ToString("MMMM");
            string year = dateTimePicker.Value.Year.ToString();

            DialogResult res = MessageBox.Show(this, $"Please ensure the encoded data is accurate before saving. If any discrepancies are found, escalate the issue to the Audit Department.\nDo you wish to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;

            await Task.Run(() => {
                try
                {
                    RemoveToOverWrite(month, year);
                    InsertDataToDB(month, year);
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate {
                        MessageBox.Show(this, $"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            });

            GatherCurrentSalesIncentives();

            if (btnText.Equals("Pre-Save"))
                btnSave.Text = "Final-Save";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            string month = dateTimePicker.Value.Month.ToString();
            string monthStr = dateTimePicker.Value.ToString("MMMM");
            string year = dateTimePicker.Value.Year.ToString();

            DialogResult res = MessageBox.Show(this, $"Do you wish to clear your records in {monthStr} {year} Sales Incentives Report?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;

            RemoveToOverWrite(month, year);
            GatherOutlets();

            btnSave.Text = "Pre-Save";
        }

        private void dateTimePicker_DropDown(object sender, EventArgs e)
        {
           
        }
    }
}
