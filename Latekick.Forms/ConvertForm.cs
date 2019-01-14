using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

using Latekick.BLL;


namespace Latekick.Forms
{
    public partial class ConvertForm : MDIBase
    {
        public ConvertForm()
        {
            InitializeComponent();
            uccMeetings.Value = DateTime.Today;
            tbLKUser.Text = Properties.Settings.Default["LKuser"].ToString();
            tbLKPass.Text = Properties.Settings.Default["LKpass"].ToString();
        }
        
        public ConvertForm(int formid) : this()
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCredentials.Checked)
                {
                    Latekick.Forms.Properties.Settings.Default["LKuser"] = tbLKUser.Text;
                    Latekick.Forms.Properties.Settings.Default["LKpass"] = tbLKPass.Text;
                    Latekick.Forms.Properties.Settings.Default.Save();
                }
                ProcessBRISFiles();
                ProcessTrackmasterFiles();
            }
            catch (Latekick.BLL.AccountManagement.User.PurchaseException pe)
            {
                ExceptionPolicy.HandleException(pe, "Latekick Exception Policy");
                Utility.SendFeedbackMessage(lvFeedback, "Could not update account");
            }
            catch (Exception e3)
            {
                ExceptionPolicy.HandleException(e3, "Latekick Exception Policy");
                Utility.SendFeedbackMessage(lvFeedback, "Error: " + e3.Message);
            }
            finally
            {
                ((MainForm)this.MdiParent).RefreshBalance();
                button1.Enabled = true;
            }
        }

        private void uccMeetings_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false; 
                DataTable dtBRISMeetings = Latekick.BLL.Base.MeetingBL.GetBrisMeetings((DateTime)uccMeetings.Value, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\BRIS");
                ugBRISMeetings.DataBindings.Clear();
                ugBRISMeetings.DataSource = dtBRISMeetings;
                ugBRISMeetings.DataBind();
                ugBRISMeetings.DisplayLayout.Override.ActiveCellAppearance.Reset();
                ugBRISMeetings.DisplayLayout.Override.ActiveRowAppearance.Reset();

                DataTable dtTrackMasterMeetings = Latekick.BLL.Base.MeetingBL.GetTrackmasterMeetings((DateTime)uccMeetings.Value, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\TrackMaster");
                ugTrackmasterMeetings.DataBindings.Clear();
                ugTrackmasterMeetings.DataSource = dtTrackMasterMeetings;
                ugTrackmasterMeetings.DataBind();
                ugTrackmasterMeetings.DisplayLayout.Override.ActiveCellAppearance.Reset();
                ugTrackmasterMeetings.DisplayLayout.Override.ActiveRowAppearance.Reset();
                button1.Enabled = true;
            }
            catch (Exception e1)
            {
                ExceptionPolicy.HandleException(e1, "Latekick Exception Policy");
                Utility.SendFeedbackMessage(lvFeedback, "Error: " + e1.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.latekick.com/public/register.aspx");
        }

        private void ProcessBRISFiles()
        {
            for (int r = 0; r < ugBRISMeetings.Selected.Rows.Count; r++)
            {
                    try
                    {
                        Infragistics.Win.UltraWinGrid.UltraGridRow dr = ugBRISMeetings.Selected.Rows[r];
                        DateTime dRaceDate = DateTime.Parse(dr.Cells["Race Date"].Text);
                        string coursecode = dr.Cells["Course Code"].Text.Trim();
                        string coursecode_bris = "";
                        if (coursecode.Length == 2)
                            coursecode_bris = coursecode.ToLower() + "x";
                        else
                            coursecode_bris = coursecode.ToLower();

                        Forms.Utility.ProcessBRISFile(dRaceDate, coursecode_bris, coursecode, lvFeedback);
                    }
                    catch (Exception e2)
                    {
                        ExceptionPolicy.HandleException(e2, "Latekick Exception Policy");
                        Utility.SendFeedbackMessage(lvFeedback, "Error: " + e2.Message);
                    }
            }
        }

        private void ProcessTrackmasterFiles()
        {
            for (int r = 0; r < ugTrackmasterMeetings.Selected.Rows.Count; r++)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow dr = ugTrackmasterMeetings.Selected.Rows[r];
                    DateTime dRaceDate = DateTime.Parse(dr.Cells["Race Date"].Text);
                    string coursecode = dr.Cells["Course Code"].Text.Trim();

                    Forms.Utility.ProcessTrackmasterFile(dRaceDate, coursecode, lvFeedback);
                }
                catch (Exception e2)
                {
                    ExceptionPolicy.HandleException(e2, "Latekick Exception Policy");
                    Utility.SendFeedbackMessage(lvFeedback, "Error: " + e2.Message);
                }
            }
        }

        private void pbTrackmaster_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.trackmaster.com");
        }

        private void pbBRIS_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.brisnet.com");
        }


    }
}
