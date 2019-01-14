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
    public partial class OneClickForm : MDIBase
    {
        public OneClickForm()
        {
            InitializeComponent();
            uccMeetings.Value = DateTime.Today;

            tbBRISUser.Text = Properties.Settings.Default["BRISuser"].ToString();
            tbBRISPass.Text = Properties.Settings.Default["BRISpass"].ToString();
        }

        public OneClickForm(int formid) : this()
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
            btnOneClickBRIS.Enabled = false;
            try
            {
                if (cbBRISCredentials.Checked)
                {
                    Latekick.Forms.Properties.Settings.Default["BRISuser"] = tbBRISUser.Text;
                    Latekick.Forms.Properties.Settings.Default["BRISpass"] = tbBRISPass.Text;
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
                    wc.Credentials = new NetworkCredential(tbBRISUser.Text, tbBRISPass.Text);
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
            finally { btnOneClickBRIS.Enabled = true; }

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

        private void btnOneClickBRIS_Click(object sender, EventArgs e)
        {
            this.btnOneClickBRIS.Enabled = false;
            try
            {
                if (cbBRISCredentials.Checked)
                {
                    Latekick.Forms.Properties.Settings.Default["BRISuser"] = tbBRISUser.Text;
                    Latekick.Forms.Properties.Settings.Default["BRISpass"] = tbBRISPass.Text;
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


                    //1. Download
                    WebClient wc = new WebClient();
                    wc.Credentials = new NetworkCredential(tbBRISUser.Text, tbBRISPass.Text);
                    try
                    {
                        wc.DownloadFile(new Uri("https://www.brisnet.com/secure-bin/brisclub/brisrep.cgi/" + coursecode_bris + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "n.zip?drm" + coursecode_bris + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "n.zip"), diBRIS.FullName + "\\" + coursecode + ".zip");

                        Utility.SendFeedbackMessage(lvFeedback, "Succesfully downloaded file " + coursecode_bris + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "n.zip");
                    }
                    catch (Exception e2)
                    {
                        Utility.SendFeedbackMessage(lvFeedback, "Problem while downloading" + coursecode_bris + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "n.zip: " + e2.Message);
                        break;
                    }

                    //2. Process
                    Latekick.Forms.Utility.ProcessBRISFile(dRaceDate, coursecode_bris, coursecode, lvFeedback);

                    //3. Open
                    string pdffile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\Latekick\\" + dRaceDate.ToString("ddMMMyyyy") + "\\" + coursecode + "_" + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "_bris.pdf";
                    Utility.SendFeedbackMessage(lvFeedback, "Opening " + pdffile);
                    System.Diagnostics.Process.Start(pdffile);
                }
            }
            catch (Exception e2) { Utility.SendFeedbackMessage(lvFeedback, e2.Message); }
            finally { btnOneClickBRIS.Enabled = true; }
        }

        private void btnOneClickTrackmaster_Click(object sender, EventArgs e)
        {
            btnOneClickTrackmaster.Enabled = false;
            try
            {
                if (cbTMCredentials.Checked)
                {
                    Latekick.Forms.Properties.Settings.Default["TMuser"] = tbBRISUser.Text;
                    Latekick.Forms.Properties.Settings.Default["TMpass"] = tbBRISPass.Text;
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

                    //1. Download 
                    //WebClient wc = new WebClient();
                    //wc.Credentials = new NetworkCredential(tbTMUser.Text, tbTMPass.Text);

                    Latekick.BLL.Download.TrackmasterDownloader tdl = new BLL.Download.TrackmasterDownloader(tbTMUser.Text, tbTMPass.Text);
                    try
                    {
                        //wc.DownloadFile(new Uri("http://www.trackmaster.com/nm/tpp_link/download/nm/TM_WEB/" + coursecode.ToLower() + dRaceDate.Year + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "ppsxml.zip"), diTrackmaster.FullName + "\\" + coursecode + ".zip");
                        tdl.DownloadRaceCard(dRaceDate, coursecode);
                        Utility.SendFeedbackMessage(lvFeedback, coursecode + dRaceDate.Year + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "ppsxml.zip");
                    }
                    catch (Exception e2)
                    {
                        Utility.SendFeedbackMessage(lvFeedback, "Problem while downloading" + coursecode + dRaceDate.Year + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "ppsxml.zip: " + e2.Message);
                        break;
                    }

                    //2. Process
                    Latekick.Forms.Utility.ProcessTrackmasterFile(dRaceDate, coursecode, lvFeedback);

                    //3. Open
                    string pdffile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\Latekick\\" + dRaceDate.ToString("ddMMMyyyy") + "\\" + coursecode + "_" + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "_trackmaster.pdf";
                    Utility.SendFeedbackMessage(lvFeedback, "Opening " + pdffile);
                    System.Diagnostics.Process.Start(pdffile);
                }
            }
            catch (Exception e2) { Utility.SendFeedbackMessage(lvFeedback, e2.Message); }
            finally { btnOneClickTrackmaster.Enabled = true; }
        }

    }
}