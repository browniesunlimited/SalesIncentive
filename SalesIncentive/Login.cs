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

namespace SalesIncentive
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            //txtBoxEmployeeID.Text = "550149931";
            //txtBoxPassword.Text = "P@ssw0rd";

            bool tryLogin = new LoginService().TryLogin(txtBoxEmployeeID.Text, txtBoxPassword.Text);

            if (tryLogin)
            {

               
                MainForm form = new MainForm(txtBoxEmployeeID.Text);

                this.Hide();
                form.ShowDialog();
            }
            else
            {
                txtBoxPassword.Text = "";
                MessageBox.Show("Invalid Username or Password", "System Errror");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
