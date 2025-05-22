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
    public partial class SCRF : Form
    {
        public SCRF()
        {
            InitializeComponent();

            dateTimeFrom.CustomFormat = "MMMM yyyy";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadData()
        {
            dataGridCredit.Rows.Clear();
            dataGridSCRF.Rows.Clear();

            var list = new DistributionService().GetForSCRF(dateTimeFrom.Value.Month, dateTimeFrom.Value.Year);

            list.ForEach(r =>
            {
                dataGridCredit.Rows.Add(r.EmpID, r.EmployeeName);
            });

            var scrf = new DistributionService().GetSavedSCRF(dateTimeFrom.Value.Month, dateTimeFrom.Value.Year);

            scrf.ForEach(r =>
            {
                dataGridSCRF.Rows.Add(r.EmpID, r.EmployeeName);
            });
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Toggle(string _SCRF, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridCredit_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridCredit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var db = new DatabaseService();

            DataGridViewRow row = dataGridCredit.Rows[e.RowIndex];

            int ID = int.Parse(row.Cells[0].Value.ToString());

            SCRFModel scrf = new SCRFModel();

            scrf.EmpID = ID;

            scrf.EmployeeName = row.Cells[1].Value.ToString();

            scrf.Month = dateTimeFrom.Value.Month;

            scrf.Year = dateTimeFrom.Value.Year;

            string errorMessage = db.SaveSCRF(scrf);

            if (errorMessage == "")
                LoadData();
            else
                MessageBox.Show(errorMessage, "System Error");
        }

        private void dataGridSCRF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var db = new DatabaseService();

            DataGridViewRow row = dataGridSCRF.Rows[e.RowIndex];

            int ID = int.Parse(row.Cells[0].Value.ToString());

            SCRFModel scrf = new SCRFModel();

            scrf.EmpID = ID;

            scrf.Month = dateTimeFrom.Value.Month;

            scrf.Year = dateTimeFrom.Value.Year;

            string errorMessage = db.DeleteSCRF(scrf);

            if (errorMessage == "")
                LoadData();
            else
                MessageBox.Show(errorMessage, "System Error");
        }
    }
}
