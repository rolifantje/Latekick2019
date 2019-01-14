using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Latekick.Forms
{
    public partial class DownloadBRISForm : MDIBase
    {
        public DownloadBRISForm()
        {
            InitializeComponent();
            uccMeetings.Value = DateTime.Today;

            tbUser.Text = Properties.Settings.Default["BRISuser"].ToString();
            tbPass.Text = Properties.Settings.Default["BRISpass"].ToString();
        }

        public DownloadBRISForm(int formid) : this()
        {
        }

        private void ultraCalendarCombo1_ValueChanged(object sender, EventArgs e)
        {
            DataTable dtMeetings = Latekick.BLL.Base.MeetingBL.GetMeetings((DateTime)uccMeetings.Value);

            ugMeetings.DataBindings.Clear();
            ugMeetings.DataSource = dtMeetings;
            ugMeetings.DataBind();
            ugMeetings.DisplayLayout.Override.ActiveCellAppearance.Reset();
            ugMeetings.DisplayLayout.Override.ActiveRowAppearance.Reset();
        }

        private void btnDownloadBris_Click(object sender, EventArgs e)
        {
            btnDownloadBris.Enabled = false;
            try
            {
                if (cbCredentials.Checked)
                {
                    Latekick.Forms.Properties.Settings.Default["BRISuser"] = tbUser.Text;
                    Latekick.Forms.Properties.Settings.Default["BRISpass"] = tbPass.Text;
                    Latekick.Forms.Properties.Settings.Default.Save();
                }
                DateTime dRaceDate = (DateTime)uccMeetings.Value;
                DirectoryInfo diBRIS = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\BRIS\\" + dRaceDate.ToString("ddMMMyyyy"));
                if (ugMeetings.Selected.Rows.Count > 0 && !diBRIS.Exists)
                    diBRIS.Create();

                for (int r = 0; r < ugMeetings.Selected.Rows.Count; r++)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow dr = ugMeetings.Selected.Rows[r];
                    string coursecode_bris, coursecode = dr.Cells["Course Code"].Text;
                    if (coursecode.Length == 2)
                        coursecode_bris = coursecode.ToLower() + "x";
                    else
                        coursecode_bris = coursecode.ToLower();

                    WebClient wc = new WebClient();
                    wc.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
                    try
                    {
                        wc.DownloadFile(new Uri("https://www.brisnet.com/secure-bin/brisclub/brisrep.cgi/" + coursecode_bris + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "n.zip?drm" + coursecode_bris + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "n.zip"), diBRIS.FullName + "\\" + coursecode + ".zip");

                        Utility.SendFeedbackMessage(lvFeedback, "Succesfully downloaded file " + coursecode_bris + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "n.zip");
                    }
                    catch (Exception e2)
                    {
                        Utility.SendFeedbackMessage(lvFeedback, "Problem while downloading" + coursecode_bris + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "n.zip: " + e2.Message);
                    }
                }
            }
            catch (Exception e2) { Utility.SendFeedbackMessage(lvFeedback, e2.Message); }
            finally { btnDownloadBris.Enabled = true; }

        }

        private void uccMeetings_ValueChanged(object sender, EventArgs e)
        {
            DataTable dtMeetings = Latekick.BLL.Base.MeetingBL.GetMeetings((DateTime)uccMeetings.Value);
            ugMeetings.DataBindings.Clear();
            ugMeetings.DataSource = dtMeetings;
            ugMeetings.DataBind();
            ugMeetings.DisplayLayout.Override.ActiveCellAppearance.Reset();
            ugMeetings.DisplayLayout.Override.ActiveRowAppearance.Reset();
        }

        private void llRegisterBRIS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.brisnet.com/cgi-bin/static.cgi?page=register");
        }

    }
}