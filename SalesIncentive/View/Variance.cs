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
    public partial class Variance : Form
    {
        List<SalesIncentiveVarianceModel> varianceList;

        string username;
        public Variance(string _username)
        {
            InitializeComponent();

            dateTimePicker.CustomFormat = "MMMM yyyy";

            username = _username;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int? outletNo = int.Parse(row.Cells[1].Value.ToString());

                decimal amount, spoilage;

                if (row.Cells[3].Value == null || row.Cells[3].Value.ToString() == "")
                    amount = 0;
                else
                    amount = Decimal.Parse(row.Cells[3].Value.ToString());

                if (row.Cells[4].Value == null || row.Cells[4].Value.ToString() == "")
                    spoilage = 0;
                else
                    spoilage = Decimal.Parse(row.Cells[4].Value.ToString());

                var temp = varianceList.FirstOrDefault(r => r.OutletNo == outletNo);

                temp.Amount = amount;

                temp.Spoilage = spoilage;

                temp.ModifiedBy = int.Parse(username);

                temp.ModifiedDate = DateTime.Now;
            }

            var db = new VarianceService();

            string errorMessage = db.SaveIncentiveVariance(varianceList);

            if (errorMessage == "")
                MessageBox.Show("Outlet Variance Successfully Saved!!!!", "Outlet Variance");
            else
                MessageBox.Show(errorMessage, "System Error");
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker_Leave(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
         
        private void dateTimePicker_CloseUp(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            varianceList = new VarianceService().GetVariancePerMonth(dateTimePicker.Value.Month, dateTimePicker.Value.Year);

            varianceList.ForEach(r =>
            {
                dataGridView1.Rows.Add(0, r.OutletNo, r.OutletName, r.Amount, r.Spoilage);
            });
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                Decimal i;

                if(Convert.ToString(e.FormattedValue) != "")
                if (!Decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                        e.Cancel = true;

                        MessageBox.Show("Please enter a valid numeric value", "User Input Error");
                }
                else
                {
                    //THE INPUT IS NUMERIC
                }
            }
        }
    }
}