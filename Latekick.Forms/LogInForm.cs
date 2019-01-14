using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Latekick.Forms
{
    public partial class LogInForm : Form
    {
        internal MainForm MF;

        public LogInForm()
        {
            InitializeComponent();
        }

        private void lblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.latekick.com/Public/Register.aspx");
        }

        private void lblPasswordRecovery_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.latekick.com/Public/Recovery.aspx");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Latekick.BLL.AccountManagement.User.AuthenticateUser(txtUsername.Text, txtPassword.Text))
            {
                Program.ThisUser = new Latekick.BOL.AccountManagement.User(txtUsername.Text);
                Program.ThisUser.Balance = 1000;
                //Latekick.BLL.AccountManagement.User.RefreshBalance(Program.ThisUser);

                string g = "";
                MF.EnableMenuBar(true);
                MF.RefreshBalance();
                MF.Show();

                Latekick.Forms.Properties.Settings.Default["LKuser"] = txtUsername.Text;
                Latekick.Forms.Properties.Settings.Default["LKpass"] = txtPassword.Text;
                Latekick.Forms.Properties.Settings.Default.Save();

                this.Close();
            }
            else
            {
                if (MessageBox.Show("User could not be authenticated.", "Log in error", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
                    Application.Exit();
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            this.txtUsername.Text = Properties.Settings.Default["LKuser"].ToString();
            this.txtPassword.Text = Properties.Settings.Default["LKpass"].ToString();
        }
    }
}
