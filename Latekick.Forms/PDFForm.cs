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
    public partial class PDFForm : MDIBase
    {
        public PDFForm()
        {
            InitializeComponent();
            uccMeetings.Value = DateTime.Today;
        }

        public PDFForm(int formid) : this()
        {
        }

        private void uccMeetings_ValueChanged(object sender, EventArgs e)
        {
            DataTable dtMeetings = Latekick.BLL.Base.MeetingBL.GetLatekickedMeetings((DateTime)uccMeetings.Value, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\Latekick");
            ugMeetings.DataBindings.Clear();
            ugMeetings.DataSource = dtMeetings;
            ugMeetings.DataBind();
            ugMeetings.DisplayLayout.Override.ActiveCellAppearance.Reset();
            ugMeetings.DisplayLayout.Override.ActiveRowAppearance.Reset();
        }

        private void btnViewPDF_Click(object sender, EventArgs e)
        {
            for (int r = 0; r < ugMeetings.Selected.Rows.Count; r++)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow dr = ugMeetings.Selected.Rows[r];
                DateTime dRaceDate = DateTime.Parse(dr.Cells["Race Date"].Text);
                string coursecode = dr.Cells["Course Code"].Text;
                string source = dr.Cells["Data"].Text;

                string pdffile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\Latekick\\" + dRaceDate.ToString("ddMMMyyyy") + "\\" + coursecode + "_" + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + (source == "BRIS" ? "_bris" : "_trackmaster") + ".pdf";
                System.Diagnostics.Process.Start(pdffile);
            }
        }
    }
}