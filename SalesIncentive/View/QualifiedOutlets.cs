using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesIncentive.Service;
using SalesIncentive.Model;

namespace SalesIncentive.View
{
    public partial class QualifiedOutlets : Form
    {
        string username;
        MainForm mainForm;

        public QualifiedOutlets(string _username, MainForm _mainForm)
        {
            InitializeComponent();

            username = _username;

            mainForm = _mainForm;

            dateTimeFrom.CustomFormat = "MMMM yyyy";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimeFrom_ValueChanged(object sender, EventArgs e)
        {
        }

        private void GetQualified(List<IncentiveDataModel> _incentiveList, List<SalesIncentiveAreaModel> _areaIncentiveList)
        {
            mainForm.QualifiedOutlets = _incentiveList.Where(r => r.IfQualified == true).ToList();

            lblQualifiedCount.Text = "Total Outlet Qualified: " + mainForm.QualifiedOutlets.Count;

            if (mainForm.QualifiedOutlets.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    var temp = mainForm.QualifiedOutlets.FirstOrDefault(r => r.OutletNo == int.Parse(row.Cells[1].Value.ToString()));

                    if (temp != null)
                    {
                        row.DefaultCellStyle.BackColor = Color.OrangeRed;

                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }

           

            }


            mainForm.QualifiedArea = _areaIncentiveList.Where(r => r.IfQualified == true).ToList();

            lblQualifiedArea.Text = "Total Area Qualified: " + mainForm.QualifiedArea.Count;

            if (mainForm.QualifiedArea.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewAreaManager.Rows)
                {
                    var temp = mainForm.QualifiedArea.FirstOrDefault(r => r.EmployeeName == row.Cells[0].Value.ToString());

                    if (temp != null)
                    {
                        row.DefaultCellStyle.BackColor = Color.OrangeRed;

                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }


            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DatabaseService db = new DatabaseService();

            mainForm.MonthDate = dateTimeFrom.Value.Month;

            mainForm.YearDate = dateTimeFrom.Value.Year;

            dataGridView1.Rows.Clear();

            dataGridViewAreaManager.Rows.Clear();

            mainForm.AllIncentiveList = db.GetAllIncentive(dateTimeFrom.Value.Month, dateTimeFrom.Value.Year);

            mainForm.IncentiveDays = new DistributionService().GetDaysWorkModels(dateTimeFrom.Value.Month, dateTimeFrom.Value.Year);

            mainForm.AllIncentiveList.ForEach(r =>
            {
                var temp = mainForm.IncentiveDays.Where(x => x.OutletName == r.OutletName).ToList();

                int totalDays = 0;

                temp.ForEach(x =>
                {
                    totalDays += x.DaysWork;
                });


                r.TotalDaysWork = totalDays;

                dataGridView1.Rows.Add(r.EmployeeName, r.OutletNo, r.OutletName, r.NetTarget, r.NetSales, r.Incremental,
                    r.CrewAmount, r.SpecialAmountForCrew, r.DayEnd50, r.DayEnd20, r.Variance, r.Spoilage, r.Complain);
            });
           

            mainForm.AreaIncentiveList = db.GetAllIncentiveArea(mainForm.AllIncentiveList);

            mainForm.AreaIncentiveList.ForEach(r =>
            {
                dataGridViewAreaManager.Rows.Add(r.EmployeeName, r.NetTarget, r.NetSales, r.AreaIncentive, r.AreaSpecial, r.GrandTotal, r.Incremental, r.DayEnd, r.Variance, r.VariancePercent, r.Spoilage, r.SpoilagePercent);
            });

            GetQualified(mainForm.AllIncentiveList, mainForm.AreaIncentiveList);


            mainForm.btnIncentive.Enabled = true;

            var service = new ReportService();

            service.SaveQualifiedOutletRPT(mainForm.AllIncentiveList, mainForm.AreaIncentiveList);

            btnExportReport.Visible = true;


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            mainForm.btnQualifiedOutlet.Enabled = true;

            if (mainForm.QualifiedOutlets != null)
                mainForm.btnIncentive.Enabled = true;
            else
                mainForm.btnIncentive.Enabled = false;

            this.Close();
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.DefaultExt = "csv";

            dialog.Filter = "csv files (*.csv)|*.csv";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                ExportService export = new ExportService();

                string errorMessage = export.ExportQualifiedCSV(dialog.FileName, mainForm.AllIncentiveList, mainForm.AreaIncentiveList);

                if (errorMessage == "")
                    MessageBox.Show("Sucessfully exported to .csv file", "System Message");
                else
                {
                    MessageBox.Show(errorMessage, "System Error");
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exportArea_Click(object sender, EventArgs e)
        {

        }
    }
}
