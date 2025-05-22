using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesIncentive.View;
using SalesIncentive.Model;

namespace SalesIncentive
{
    public partial class MainForm : Form
    {
        public string username;

        public List<IncentiveDataModel> QualifiedOutlets;
        public List<IncentiveDataModel> AllIncentiveList;
        public List<SalesIncentiveAreaModel> AreaIncentiveList;
        public List<SalesIncentiveAreaModel> QualifiedArea;
        public List<IncentiveDaysWorkModel> IncentiveDays;

        public int MonthDate;
        public int YearDate;

        public MainForm(string _username)
        {
            InitializeComponent();

            username = _username;

            btnIncentive.Enabled = false;
        }

        private void btnQualifiedOutlet_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            QualifiedOutlets form = new QualifiedOutlets(username, this);

            form.TopLevel = false;

            form.AutoScroll = true;

            form.Dock = DockStyle.Fill;

            panelMain.Controls.Add(form);

            form.Show();
        }

        private void btnIncentive_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            IncentiveDistribution form = new IncentiveDistribution(username, this);

            form.TopLevel = false;

            form.AutoScroll = true;

            form.Dock = DockStyle.Fill;

            panelMain.Controls.Add(form);

            form.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnEncodeVariance_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            //Variance form = new Variance(username);
            Variance_New form = new Variance_New(username);

            form.TopLevel = false;

            form.AutoScroll = true;

            form.Dock = DockStyle.Fill;

            panelMain.Controls.Add(form);

            form.Show();
        }

        private void btnWithComplain_Click(object sender, EventArgs e)
        {

        }

        private void btnSCRF_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            SCRF form = new SCRF();

            form.TopLevel = false;

            form.AutoScroll = true;

            form.Dock = DockStyle.Fill;

            panelMain.Controls.Add(form);

            form.Show();
        }
    }
}

