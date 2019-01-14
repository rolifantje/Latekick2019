using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace Latekick.Forms
{
    public partial class AccountForm : MDIBase
    {
        #region Constructors
        public AccountForm()
        {
            InitializeComponent();
        }

        public AccountForm(int formid) : this()
        {
        }
        #endregion

        private void Account_Load(object sender, EventArgs e)
        {
            txtLKUserName.Text = Properties.Settings.Default["LKuser"].ToString();
            txtLKPassword.Text = Properties.Settings.Default["LKpass"].ToString();
            txtLKEmail.Text = Properties.Settings.Default["LKemail"].ToString();

            txtBRISUserName.Text = Properties.Settings.Default["BRISuser"].ToString();
            txtBRISPassword.Text = Properties.Settings.Default["BRISpass"].ToString();

            txtTrackmasterUserName.Text = Properties.Settings.Default["TMuser"].ToString();
            txtTrackmasterPassword.Text = Properties.Settings.Default["TMpass"].ToString();
            
            this.lblBalance.Text = Utility.GetCurrencySymbol(Program.ThisUser.Currency) + " " + Program.ThisUser.Balance;
        }

        private void btnAddFunds_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.latekick.com/Protected/AddFunds.aspx?u=" + Latekick.Forms.Properties.Settings.Default["LKuser"].ToString() + "&cc=" + Program.ThisUser.Currency);
        }

        private void btnSaveLKChanges_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["LKuser"] = txtLKUserName.Text;
            Properties.Settings.Default["LKpass"] = txtLKPassword.Text;
            Properties.Settings.Default["LKemail"] = txtLKEmail.Text;
            Properties.Settings.Default.Save();
        }

        private void btnSaveBRISChanges_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["BRISuser"] = txtBRISUserName.Text;
            Properties.Settings.Default["BRISpass"] = txtBRISPassword.Text;
            Properties.Settings.Default.Save();
        }

        private void btnSaveTrackmasterChanges_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["TMuser"] = txtTrackmasterUserName.Text;
            Properties.Settings.Default["TMpass"] = txtTrackmasterPassword.Text;
            Properties.Settings.Default.Save();
        }
    }
}
