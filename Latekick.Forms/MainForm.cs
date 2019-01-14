using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Latekick.Forms
{
    public partial class MainForm : Form
    {
        private int currentFormId;
        public List<MDIBase> MDIForms { get; set; }
        private OneClickForm MDI_OneClick;
        private DownloadBRISForm MDI_BRISDownload;
        private DownloadTrackmasterForm MDI_TrackmasterDownload;
        private ConvertForm MDI_Convert;
        private PDFForm MDI_PDF;
        private AccountForm MDI_Account;

        public MainForm()
        {
            MDIForms = new List<MDIBase>();
            InitializeComponent();
            MDIForms.Add(MDI_OneClick);
            MDIForms.Add(MDI_BRISDownload);
            MDIForms.Add(MDI_TrackmasterDownload);
            MDIForms.Add(MDI_Convert);
            MDIForms.Add(MDI_PDF);
            MDIForms.Add(MDI_Account);
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "OneClick":
                    LoadOneClickForm();
                    break;
                case "Download from BRIS":
                    LoadDownloadBRISForm();
                    break;
                case "Download from Trackmaster":
                    LoadDownloadTrackmasterForm();
                    break;
                case "Extract Latekick numbers":
                    LoadConvertForm();
                    break;
                case "View PDF":
                    LoadPDFForm();
                    break;
                case "Overview":
                    LoadAccountOverviewForm();
                    break;
                case "Add Funds":
                    System.Diagnostics.Process.Start("http://www.latekick.com/Protected/AddFunds.aspx?u=" + Latekick.Forms.Properties.Settings.Default["LKuser"].ToString() + "&cc=" + Program.ThisUser.Currency);
                    break;
                case "btnExit":
                    Application.Exit();
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            LogInForm fLogIn = new LogInForm();
            fLogIn.MF = this;
            fLogIn.TopLevel = true;
            fLogIn.Show();
            EnableMenuBar(true);
        }

        private void LoadOneClickForm()
        {
            //foreach (MDIBase bf in MDIForms)
            //    if (bf != null) bf.Hide(); 
            if (MDI_OneClick == null)
            {
                MDI_OneClick = new OneClickForm(currentFormId++);
                MDI_OneClick.Text = "OneClick";
                MDI_OneClick.MdiParent = this;
                //MDI_BRISDownload.TopLevel = false;
                MDIForms[0] = MDI_OneClick;
            }
            MDI_OneClick.Show();
        }

        private void LoadDownloadBRISForm()
        {
            //foreach (MDIBase bf in MDIForms)
            //    if (bf != null) bf.Hide(); 
            if (MDI_BRISDownload == null)
            {
                MDI_BRISDownload = new DownloadBRISForm(currentFormId++);
                MDI_BRISDownload.Text = "Download BRIS";
                MDI_BRISDownload.MdiParent = this;
                //MDI_BRISDownload.TopLevel = false;
                MDIForms[1] = MDI_BRISDownload;
            }
            MDI_BRISDownload.Show();
        }

        private void LoadDownloadTrackmasterForm()
        {
            //foreach (MDIBase bf in MDIForms)
            //    if (bf != null) bf.Hide(); 
            if (MDI_TrackmasterDownload == null)
            {
                MDI_TrackmasterDownload = new DownloadTrackmasterForm(currentFormId++);
                MDI_TrackmasterDownload.Text = "Download Trackmaster";
                MDI_TrackmasterDownload.MdiParent = this;
                //MDI_BRISDownload.TopLevel = false;
                MDIForms[2] = MDI_TrackmasterDownload;
            }
            MDI_TrackmasterDownload.Show();
        }
        private void LoadConvertForm()
        {
            //foreach (MDIBase bf in MDIForms)
            //    if (bf != null) bf.Hide(); 
            if (MDI_Convert == null)
            {
                MDI_Convert = new ConvertForm(currentFormId++);
                MDI_Convert.Text = "Extract to Latekick";
                MDI_Convert.MdiParent = this;
                //MDI_Convert.TopLevel = false;
                MDIForms[3] = MDI_Convert;
            }
            MDI_Convert.Show();
        }
        private void LoadPDFForm()
        {
            //foreach (MDIBase bf in MDIForms)
            //    if (bf != null) bf.Hide(); 
            if (MDI_PDF == null)
            {
                MDI_PDF = new PDFForm(currentFormId++);
                MDI_PDF.Text = "Select PDF";
                MDI_PDF.MdiParent = this;
                //MDI_PDF.TopLevel = false;
                MDIForms[4] = MDI_PDF;
            }
            MDI_PDF.Show();
        }
        private void LoadAccountOverviewForm()
        {
            //foreach (MDIBase bf in MDIForms)
            //    if (bf != null) bf.Hide(); 
            if (MDI_Account == null)
            {
                MDI_Account = new AccountForm(currentFormId++);
                MDI_Account.Text = "Account overview";
                MDI_Account.MdiParent = this;
                //MDI_PDF.TopLevel = false;
                MDIForms[5] = MDI_Account;
            }
            MDIForms[5].Show();
        }

        private void UnLoadOneClickForm()
        {
            MDI_OneClick = null;
            MDIForms[0] = null;
        }
        private void UnLoadDownloadBRISForm()
        {
            MDI_BRISDownload = null;
            MDIForms[1] = null;
        }
        private void UnLoadDownloadTrackmasterForm()
        {
            MDI_BRISDownload = null;
            MDIForms[2] = null;
        }
        private void UnloadConvertForm()
        {
            MDI_Convert = null;
            MDIForms[3] = null;
        }
        private void UnloadPDFForm()
        {
            MDI_PDF = null;
            MDIForms[4] = null;
        }
        private void UnloadAccountOverviewForm()
        {
            MDI_Account = null;
            MDIForms[5] = null;
        }

        public void EnableMenuBar(bool enable)
        {
            this.ultraToolbarsManager1.Enabled = enable;
        }

        public void RefreshBalance()
        {
            Infragistics.Win.UltraWinToolbars.LabelTool b = (Infragistics.Win.UltraWinToolbars.LabelTool)this.ultraToolbarsManager1.Tools["Balance"];
            b.SharedProps.Caption = Program.ThisUser.Balance + " conversions left";
        }

        private void ultratabmanager_TabClosing(object sender, Infragistics.Win.UltraWinTabbedMdi.CancelableMdiTabEventArgs e)
        {
            switch (e.Tab.TextResolved)
            {
                case "OneClick":
                    UnLoadOneClickForm();
                    break;
                case "Download BRIS":
                    UnLoadDownloadBRISForm();
                    break;
                case "Download Trackmaster":
                    UnLoadDownloadTrackmasterForm();
                    break;
                case "Extract to Latekick":
                    UnloadConvertForm();
                    break;
                case "Select PDF":
                    UnloadPDFForm();
                    break;
                case "Account overview":
                    UnloadAccountOverviewForm();
                    break;
            }
        }
    }
}