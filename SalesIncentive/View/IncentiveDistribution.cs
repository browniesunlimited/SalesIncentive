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
    public partial class IncentiveDistribution : Form
    {
        string username;

        MainForm mainForm;

        List<SalesIncentiveCrewModel> crewIncentiveList;

        public IncentiveDistribution(string _username, MainForm _mainForm)
        {
            InitializeComponent();

            panelAreaWarning.Visible = false;

            panelCrewWarning.Visible = false;

            username = _username;

            mainForm = _mainForm;

            GetCrew();

            GetArea();
        }

        private void GetArea()
        {
            dataGridViewArea.Rows.Clear();

            mainForm.QualifiedArea.ForEach(r =>
            {
                dataGridViewArea.Rows.Add(r.EmployeeName, r.BankAccount, r.AreaIncentive, r.AreaSpecial, r.TotalAmount);
            });

            if (mainForm.QualifiedArea.Count == 0)
                panelAreaWarning.Visible = true;
        }

        private void GetCrew()
        {
            dataGridCrew.Rows.Clear();

            crewIncentiveList = new DistributionService().DistributeToCrew(mainForm.QualifiedOutlets, mainForm.IncentiveDays).OrderBy(r=>r.OutletName).ToList();

            crewIncentiveList.ForEach(r =>
            {
                dataGridCrew.Rows.Add(r.OutletName, r.EmpID, r.EmployeeName, r.BankAccountNo, r.DaysWork, r.IncentiveAmount, r.SpecialAmount,
                    r.IncentiveToReceive, r.SpecialToReceive, r.GrandTotal);
            });

            if (crewIncentiveList.Count == 0)
                panelCrewWarning.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

        }


        private void btnSCRF_Click(object sender, EventArgs e)
        {
            SCRF form = new SCRF();

            form.ShowDialog();
        }

        private void btnGenerateBankFile_Click(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openDialog = new FolderBrowserDialog();

            if(openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var service = new BankFileService();

                string errorMessage = "";

                var bankCheck = crewIncentiveList.Where(r => r.BankAccountNo == null).ToList();

                bankCheck.ForEach(r =>
                {
                    errorMessage += "NO BANK ACCOUNT: " + r.EmployeeName + "\n";
                });

                var areaCheck = mainForm.QualifiedArea.Where(r => r.BankAccount == null).ToList();

                areaCheck.ForEach(r =>
                {
                    errorMessage += "NO BANK ACCOUNT: " + r.EmployeeName + "\n";
                });

                if (errorMessage != "")
                    MessageBox.Show(errorMessage, "System Error");
                else
                {

                    errorMessage = service.SaveBankFile(crewIncentiveList, mainForm.QualifiedArea, mainForm.MonthDate, mainForm.YearDate, int.Parse(mainForm.username));

                    if (errorMessage != "")
                        MessageBox.Show(errorMessage, "System Error");
                    else
                    {
                        var path = openDialog.SelectedPath;

                        errorMessage = service.GenerateBankFile(path, mainForm.MonthDate, mainForm.YearDate);

                        if (errorMessage == "")
                            MessageBox.Show("Successfully saved", "Notification");
                        else
                            MessageBox.Show(errorMessage, "System Error");
                    }
                }
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.DefaultExt = "csv";

            dialog.Filter = "csv files (*.csv|*csv";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                ExportService export = new ExportService();

                string errorMessage = export.ExportDistribution(dialog.FileName, crewIncentiveList, mainForm.QualifiedArea);

                if (errorMessage == "")
                    MessageBox.Show("Successfull exported to .csv file", "System Message");
                else
                    MessageBox.Show(errorMessage, "System Error");

            }
        }
    }
}
