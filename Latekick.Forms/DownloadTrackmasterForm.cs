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
using Latekick.BLL;

namespace Latekick.Forms
{
    public partial class DownloadTrackmasterForm : MDIBase
    {
        public DownloadTrackmasterForm()
        {
            InitializeComponent();
            uccMeetings.Value = DateTime.Today;

            tbUser.Text = Properties.Settings.Default["TMuser"].ToString();
            tbPass.Text = Properties.Settings.Default["TMpass"].ToString();
        }

        public DownloadTrackmasterForm(int formid) : this()
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

        private void uccMeetings_ValueChanged(object sender, EventArgs e)
        {
            DataTable dtMeetings = Latekick.BLL.Base.MeetingBL.GetMeetings((DateTime)uccMeetings.Value);
            ugMeetings.DataBindings.Clear();
            ugMeetings.DataSource = dtMeetings;
            ugMeetings.DataBind();
            ugMeetings.DisplayLayout.Override.ActiveCellAppearance.Reset();
            ugMeetings.DisplayLayout.Override.ActiveRowAppearance.Reset();
        }

        private void llRegisterTrackmaster_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.trackmaster.com/cgi-bin/register.cgi?tpp");
        }

        private void btnDownloadTrackmaster_Click(object sender, EventArgs e)
        {
            btnDownloadTrackmaster.Enabled = false;
            try
            {
                if (cbCredentials.Checked)
                {
                    Latekick.Forms.Properties.Settings.Default["TMuser"] = tbUser.Text;
                    Latekick.Forms.Properties.Settings.Default["TMpass"] = tbPass.Text;
                    Latekick.Forms.Properties.Settings.Default.Save();
                }
                DateTime dRaceDate = (DateTime)uccMeetings.Value;
                DirectoryInfo diTrackmaster = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\Trackmaster\\" + dRaceDate.ToString("ddMMMyyyy"));
                if (ugMeetings.Selected.Rows.Count > 0 && !diTrackmaster.Exists)
                    diTrackmaster.Create();

                for (int r = 0; r < ugMeetings.Selected.Rows.Count; r++)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow dr = ugMeetings.Selected.Rows[r];
                    string coursecode = dr.Cells["Course Code"].Text;

                    //WebClient wc = new WebClient();
                    //wc.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);

                    Latekick.BLL.Download.TrackmasterDownloader tdl = new Latekick.BLL.Download.TrackmasterDownloader(tbUser.Text, tbPass.Text);

                    try
                    {
                        //TMC.DownloadFile(new Uri("http://www.trackmaster.com/nm/tpp_link/download/nm/TM_WEB/" + coursecode.ToLower() + dRaceDate.Year + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "ppsxml.zip"), diTrackmaster.FullName + "\\" + coursecode + ".zip");
                        tdl.DownloadRaceCard(dRaceDate, coursecode);


                        Utility.SendFeedbackMessage(lvFeedback, coursecode + dRaceDate.Year + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "ppsxml.zip");
                    }
                    catch (Exception e2)
                    {
                        Utility.SendFeedbackMessage(lvFeedback, "Problem while downloading" + coursecode + dRaceDate.Year + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "ppsxml.zip: " + e2.Message);
                    }
                }
            }
            catch (Exception e2) { Utility.SendFeedbackMessage(lvFeedback, e2.Message); }
            finally { btnDownloadTrackmaster.Enabled = true; }
        }
    }
}