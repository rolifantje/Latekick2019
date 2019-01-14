using System;
using System.Windows.Forms;

namespace Latekick.Forms
{
    public partial class MDIBase : Form
    {
        #region Constructors

        public MDIBase()
        {
            InitializeComponent();
        }

        public MDIBase(int formid) : this()
        {
            FormId = formid;
        }
        #endregion

        private void MDIBase_Load(object sender, EventArgs e)
        {
            AutoScroll = true;
            // DO NOT CHANGE THESE SETTINGS, NEEDED FOR INFRAGISTICS TAB CONTROLS
            //ControlBox = false;
            //Text = string.Empty;
            //FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //MinimumSize = new Size(1024, 768);
        }

        #region Properties:

        public string FormCaption { get; protected set; }

        public int FormId { get; protected set; }

        #endregion

        #region Events:

        private void LatekickContentForm_SizeChanged(object sender, EventArgs e)
        {
            //FormBorderStyle = WindowState != FormWindowState.Maximized ? FormBorderStyle.FixedSingle : FormBorderStyle.None;
        }

        private void LatekickContentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm main = (MainForm)this.Parent.Parent;
            //main.MDIForms.Remove(this);
        }

        #endregion

        #region Methods:

        protected void DisableForm()
        {
            //ComponentUtility.DisableControl(this);
        }

        #endregion
    }
}