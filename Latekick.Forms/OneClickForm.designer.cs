namespace Latekick.Forms
{
    partial class OneClickForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            this.lblDate = new Infragistics.Win.Misc.UltraLabel();
            this.uccMeetings = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.ugMeetings = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulInfo1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.lvFeedback = new System.Windows.Forms.ListView();
            this.ch_Header = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.tbBRISUser = new System.Windows.Forms.TextBox();
            this.tbBRISPass = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabProvider = new System.Windows.Forms.TabControl();
            this.tabBRIS = new System.Windows.Forms.TabPage();
            this.btnOneClickBRIS = new System.Windows.Forms.Button();
            this.llRegisterBRIS = new System.Windows.Forms.LinkLabel();
            this.cbBRISCredentials = new System.Windows.Forms.CheckBox();
            this.tabTM = new System.Windows.Forms.TabPage();
            this.btnOneClickTrackmaster = new System.Windows.Forms.Button();
            this.llRegisterTrackmaster = new System.Windows.Forms.LinkLabel();
            this.cbTMCredentials = new System.Windows.Forms.CheckBox();
            this.tbTMPass = new System.Windows.Forms.TextBox();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.tbTMUser = new System.Windows.Forms.TextBox();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.uccMeetings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugMeetings)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabProvider.SuspendLayout();
            this.tabBRIS.SuspendLayout();
            this.tabTM.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            appearance11.FontData.BoldAsString = "True";
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.lblDate.Appearance = appearance11;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(6, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(160, 21);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Select a date:";
            // 
            // uccMeetings
            // 
            this.uccMeetings.DateButtons.Add(dateButton1);
            this.uccMeetings.Location = new System.Drawing.Point(183, 9);
            this.uccMeetings.MinimumDaySize = new System.Drawing.Size(25, 25);
            appearance14.TextHAlignAsString = "Center";
            this.uccMeetings.MonthPopupAppearance = appearance14;
            this.uccMeetings.Name = "uccMeetings";
            this.uccMeetings.NonAutoSizeHeight = 21;
            this.uccMeetings.Size = new System.Drawing.Size(121, 21);
            this.uccMeetings.TabIndex = 7;
            this.uccMeetings.Value = "";
            this.uccMeetings.ValueChanged += new System.EventHandler(this.uccMeetings_ValueChanged);
            // 
            // ugMeetings
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugMeetings.DisplayLayout.Appearance = appearance1;
            this.ugMeetings.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugMeetings.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.ugMeetings.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugMeetings.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.ugMeetings.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugMeetings.DisplayLayout.GroupByBox.Hidden = true;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugMeetings.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.ugMeetings.DisplayLayout.MaxColScrollRegions = 1;
            this.ugMeetings.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugMeetings.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugMeetings.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.ugMeetings.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.ugMeetings.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugMeetings.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.ugMeetings.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugMeetings.DisplayLayout.Override.CellAppearance = appearance8;
            this.ugMeetings.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.ugMeetings.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.ugMeetings.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.ugMeetings.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.ugMeetings.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugMeetings.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.ugMeetings.DisplayLayout.Override.RowAppearance = appearance12;
            this.ugMeetings.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.ugMeetings.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugMeetings.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.ugMeetings.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugMeetings.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugMeetings.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugMeetings.Location = new System.Drawing.Point(6, 36);
            this.ugMeetings.Name = "ugMeetings";
            this.ugMeetings.Size = new System.Drawing.Size(298, 396);
            this.ugMeetings.TabIndex = 9;
            this.ugMeetings.Text = "ultraGrid1";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(17, 82);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(412, 43);
            this.ultraLabel1.TabIndex = 10;
            this.ultraLabel1.Text = "2) The Latekick numbers will be extracted automatically once the files have been " +
    "downloaded.";
            // 
            // ulInfo1
            // 
            this.ulInfo1.Location = new System.Drawing.Point(20, 19);
            this.ulInfo1.Name = "ulInfo1";
            this.ulInfo1.Size = new System.Drawing.Size(409, 45);
            this.ulInfo1.TabIndex = 12;
            this.ulInfo1.Text = "1) Select the cards you want to download (You can select multiple cards by holdin" +
    "g down the CTRL button when you click).";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(70, 27);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(138, 19);
            this.ultraLabel2.TabIndex = 13;
            this.ultraLabel2.Text = "BRIS username:";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(17, 131);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(412, 43);
            this.ultraLabel3.TabIndex = 14;
            this.ultraLabel3.Text = "3) BRIS charges $1.00 for downloading a file. For Trackmaster, it depends on your" +
    " subscription plan. The Latekick conversion costs $1.00.";
            // 
            // lvFeedback
            // 
            this.lvFeedback.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Header,
            this.ch_Time,
            this.ch_Message});
            this.lvFeedback.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvFeedback.Location = new System.Drawing.Point(0, 777);
            this.lvFeedback.Name = "lvFeedback";
            this.lvFeedback.Size = new System.Drawing.Size(1194, 207);
            this.lvFeedback.TabIndex = 15;
            this.lvFeedback.UseCompatibleStateImageBehavior = false;
            this.lvFeedback.View = System.Windows.Forms.View.Details;
            // 
            // ch_Header
            // 
            this.ch_Header.Width = 10;
            // 
            // ch_Time
            // 
            this.ch_Time.Text = "Time";
            this.ch_Time.Width = 100;
            // 
            // ch_Message
            // 
            this.ch_Message.Text = "Message";
            this.ch_Message.Width = 600;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel4.Location = new System.Drawing.Point(70, 52);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(138, 19);
            this.ultraLabel4.TabIndex = 16;
            this.ultraLabel4.Text = "BRIS password:";
            // 
            // tbBRISUser
            // 
            this.tbBRISUser.Location = new System.Drawing.Point(214, 24);
            this.tbBRISUser.Name = "tbBRISUser";
            this.tbBRISUser.Size = new System.Drawing.Size(141, 20);
            this.tbBRISUser.TabIndex = 17;
            // 
            // tbBRISPass
            // 
            this.tbBRISPass.Location = new System.Drawing.Point(214, 51);
            this.tbBRISPass.Name = "tbBRISPass";
            this.tbBRISPass.PasswordChar = '*';
            this.tbBRISPass.Size = new System.Drawing.Size(141, 20);
            this.tbBRISPass.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabProvider);
            this.groupBox1.Location = new System.Drawing.Point(348, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 219);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // tabProvider
            // 
            this.tabProvider.Controls.Add(this.tabBRIS);
            this.tabProvider.Controls.Add(this.tabTM);
            this.tabProvider.Location = new System.Drawing.Point(16, 16);
            this.tabProvider.Name = "tabProvider";
            this.tabProvider.SelectedIndex = 0;
            this.tabProvider.Size = new System.Drawing.Size(417, 196);
            this.tabProvider.TabIndex = 0;
            // 
            // tabBRIS
            // 
            this.tabBRIS.Controls.Add(this.btnOneClickBRIS);
            this.tabBRIS.Controls.Add(this.llRegisterBRIS);
            this.tabBRIS.Controls.Add(this.ultraLabel4);
            this.tabBRIS.Controls.Add(this.tbBRISUser);
            this.tabBRIS.Controls.Add(this.cbBRISCredentials);
            this.tabBRIS.Controls.Add(this.ultraLabel2);
            this.tabBRIS.Controls.Add(this.tbBRISPass);
            this.tabBRIS.Location = new System.Drawing.Point(4, 22);
            this.tabBRIS.Name = "tabBRIS";
            this.tabBRIS.Padding = new System.Windows.Forms.Padding(3);
            this.tabBRIS.Size = new System.Drawing.Size(409, 170);
            this.tabBRIS.TabIndex = 0;
            this.tabBRIS.Text = "BRIS";
            this.tabBRIS.UseVisualStyleBackColor = true;
            // 
            // btnOneClickBRIS
            // 
            this.btnOneClickBRIS.Location = new System.Drawing.Point(70, 117);
            this.btnOneClickBRIS.Name = "btnOneClickBRIS";
            this.btnOneClickBRIS.Size = new System.Drawing.Size(285, 33);
            this.btnOneClickBRIS.TabIndex = 21;
            this.btnOneClickBRIS.Text = "Let\'s go";
            this.btnOneClickBRIS.UseVisualStyleBackColor = true;
            this.btnOneClickBRIS.Click += new System.EventHandler(this.btnOneClickBRIS_Click);
            // 
            // llRegisterBRIS
            // 
            this.llRegisterBRIS.AutoSize = true;
            this.llRegisterBRIS.Location = new System.Drawing.Point(224, 79);
            this.llRegisterBRIS.Name = "llRegisterBRIS";
            this.llRegisterBRIS.Size = new System.Drawing.Size(97, 13);
            this.llRegisterBRIS.TabIndex = 20;
            this.llRegisterBRIS.TabStop = true;
            this.llRegisterBRIS.Text = "No BRIS account?";
            this.llRegisterBRIS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRegisterBRIS_LinkClicked);
            // 
            // cbBRISCredentials
            // 
            this.cbBRISCredentials.AutoSize = true;
            this.cbBRISCredentials.Location = new System.Drawing.Point(70, 79);
            this.cbBRISCredentials.Name = "cbBRISCredentials";
            this.cbBRISCredentials.Size = new System.Drawing.Size(142, 17);
            this.cbBRISCredentials.TabIndex = 19;
            this.cbBRISCredentials.Text = "Store credentials (if new)";
            this.cbBRISCredentials.UseVisualStyleBackColor = true;
            // 
            // tabTM
            // 
            this.tabTM.Controls.Add(this.btnOneClickTrackmaster);
            this.tabTM.Controls.Add(this.llRegisterTrackmaster);
            this.tabTM.Controls.Add(this.cbTMCredentials);
            this.tabTM.Controls.Add(this.tbTMPass);
            this.tabTM.Controls.Add(this.ultraLabel5);
            this.tabTM.Controls.Add(this.tbTMUser);
            this.tabTM.Controls.Add(this.ultraLabel6);
            this.tabTM.Location = new System.Drawing.Point(4, 22);
            this.tabTM.Name = "tabTM";
            this.tabTM.Padding = new System.Windows.Forms.Padding(3);
            this.tabTM.Size = new System.Drawing.Size(409, 170);
            this.tabTM.TabIndex = 1;
            this.tabTM.Text = "Trackmaster";
            this.tabTM.UseVisualStyleBackColor = true;
            // 
            // btnOneClickTrackmaster
            // 
            this.btnOneClickTrackmaster.Location = new System.Drawing.Point(70, 117);
            this.btnOneClickTrackmaster.Name = "btnOneClickTrackmaster";
            this.btnOneClickTrackmaster.Size = new System.Drawing.Size(285, 33);
            this.btnOneClickTrackmaster.TabIndex = 28;
            this.btnOneClickTrackmaster.Text = "Let\'s go";
            this.btnOneClickTrackmaster.UseVisualStyleBackColor = true;
            this.btnOneClickTrackmaster.Click += new System.EventHandler(this.btnOneClickTrackmaster_Click);
            // 
            // llRegisterTrackmaster
            // 
            this.llRegisterTrackmaster.AutoSize = true;
            this.llRegisterTrackmaster.Location = new System.Drawing.Point(224, 79);
            this.llRegisterTrackmaster.Name = "llRegisterTrackmaster";
            this.llRegisterTrackmaster.Size = new System.Drawing.Size(131, 13);
            this.llRegisterTrackmaster.TabIndex = 27;
            this.llRegisterTrackmaster.TabStop = true;
            this.llRegisterTrackmaster.Text = "No Trackmaster account?";
            // 
            // cbTMCredentials
            // 
            this.cbTMCredentials.AutoSize = true;
            this.cbTMCredentials.Location = new System.Drawing.Point(70, 79);
            this.cbTMCredentials.Name = "cbTMCredentials";
            this.cbTMCredentials.Size = new System.Drawing.Size(142, 17);
            this.cbTMCredentials.TabIndex = 26;
            this.cbTMCredentials.Text = "Store credentials (if new)";
            this.cbTMCredentials.UseVisualStyleBackColor = true;
            // 
            // tbTMPass
            // 
            this.tbTMPass.Location = new System.Drawing.Point(214, 51);
            this.tbTMPass.Name = "tbTMPass";
            this.tbTMPass.PasswordChar = '*';
            this.tbTMPass.Size = new System.Drawing.Size(141, 20);
            this.tbTMPass.TabIndex = 25;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel5.Location = new System.Drawing.Point(70, 27);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(138, 19);
            this.ultraLabel5.TabIndex = 22;
            this.ultraLabel5.Text = "Trackmaster username:";
            // 
            // tbTMUser
            // 
            this.tbTMUser.Location = new System.Drawing.Point(214, 24);
            this.tbTMUser.Name = "tbTMUser";
            this.tbTMUser.Size = new System.Drawing.Size(141, 20);
            this.tbTMUser.TabIndex = 24;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel6.Location = new System.Drawing.Point(70, 52);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(138, 19);
            this.ultraLabel6.TabIndex = 23;
            this.ultraLabel6.Text = "Trackmaster password:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ulInfo1);
            this.groupBox2.Controls.Add(this.ultraLabel1);
            this.groupBox2.Controls.Add(this.ultraLabel3);
            this.groupBox2.Location = new System.Drawing.Point(348, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 214);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ugMeetings);
            this.groupBox3.Controls.Add(this.uccMeetings);
            this.groupBox3.Controls.Add(this.lblDate);
            this.groupBox3.Location = new System.Drawing.Point(23, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 438);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // OneClickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 984);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvFeedback);
            this.MaximumSize = new System.Drawing.Size(0, 0);
            this.Name = "OneClickForm";
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.uccMeetings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugMeetings)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabProvider.ResumeLayout(false);
            this.tabBRIS.ResumeLayout(false);
            this.tabBRIS.PerformLayout();
            this.tabTM.ResumeLayout(false);
            this.tabTM.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel lblDate;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccMeetings;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugMeetings;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ulInfo1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private System.Windows.Forms.ListView lvFeedback;
        private System.Windows.Forms.ColumnHeader ch_Time;
        private System.Windows.Forms.ColumnHeader ch_Message;
        private System.Windows.Forms.ColumnHeader ch_Header;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private System.Windows.Forms.TextBox tbBRISUser;
        private System.Windows.Forms.TextBox tbBRISPass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbBRISCredentials;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel llRegisterBRIS;
        private System.Windows.Forms.TabControl tabProvider;
        private System.Windows.Forms.TabPage tabBRIS;
        private System.Windows.Forms.TabPage tabTM;
        private System.Windows.Forms.Button btnOneClickBRIS;
        private System.Windows.Forms.Button btnOneClickTrackmaster;
        private System.Windows.Forms.LinkLabel llRegisterTrackmaster;
        private System.Windows.Forms.CheckBox cbTMCredentials;
        private System.Windows.Forms.TextBox tbTMPass;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private System.Windows.Forms.TextBox tbTMUser;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
    }
}