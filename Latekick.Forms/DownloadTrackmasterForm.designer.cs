namespace Latekick.Forms
{
    partial class DownloadTrackmasterForm
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
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
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
            this.btnDownloadTrackmaster = new System.Windows.Forms.Button();
            this.ulInfo1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.lvFeedback = new System.Windows.Forms.ListView();
            this.ch_Header = new System.Windows.Forms.ColumnHeader();
            this.ch_Time = new System.Windows.Forms.ColumnHeader();
            this.ch_Message = new System.Windows.Forms.ColumnHeader();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.llRegisterTrackmaster = new System.Windows.Forms.LinkLabel();
            this.cbCredentials = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.uccMeetings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugMeetings)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.uccMeetings.DateButtons.Add(dateButton2);
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
            this.ultraLabel1.Size = new System.Drawing.Size(231, 43);
            this.ultraLabel1.TabIndex = 10;
            this.ultraLabel1.Text = "2) The Latekick numbers can be extracted once the files have been downloaded.";
            // 
            // btnDownloadTrackmaster
            // 
            this.btnDownloadTrackmaster.Location = new System.Drawing.Point(36, 127);
            this.btnDownloadTrackmaster.Name = "btnDownloadTrackmaster";
            this.btnDownloadTrackmaster.Size = new System.Drawing.Size(262, 72);
            this.btnDownloadTrackmaster.TabIndex = 11;
            this.btnDownloadTrackmaster.Text = "Download File(s)";
            this.btnDownloadTrackmaster.UseVisualStyleBackColor = true;
            this.btnDownloadTrackmaster.Click += new System.EventHandler(this.btnDownloadTrackmaster_Click);
            // 
            // ulInfo1
            // 
            this.ulInfo1.Location = new System.Drawing.Point(20, 19);
            this.ulInfo1.Name = "ulInfo1";
            this.ulInfo1.Size = new System.Drawing.Size(250, 45);
            this.ulInfo1.TabIndex = 12;
            this.ulInfo1.Text = "1) Select the cards you want to download from Trackmaster (by holding the CTRL bu" +
                "tton you can select multiple cards).";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(36, 40);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(138, 19);
            this.ultraLabel2.TabIndex = 13;
            this.ultraLabel2.Text = "Trackmaster username:";
            // 
            // lvFeedback
            // 
            this.lvFeedback.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Header,
            this.ch_Time,
            this.ch_Message});
            this.lvFeedback.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvFeedback.Location = new System.Drawing.Point(0, 477);
            this.lvFeedback.Name = "lvFeedback";
            this.lvFeedback.Size = new System.Drawing.Size(878, 207);
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
            this.ultraLabel4.Location = new System.Drawing.Point(36, 65);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(138, 19);
            this.ultraLabel4.TabIndex = 16;
            this.ultraLabel4.Text = "Trackmaster password:";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(180, 37);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(141, 20);
            this.tbUser.TabIndex = 17;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(180, 64);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(141, 20);
            this.tbPass.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.llRegisterTrackmaster);
            this.groupBox1.Controls.Add(this.cbCredentials);
            this.groupBox1.Controls.Add(this.btnDownloadTrackmaster);
            this.groupBox1.Controls.Add(this.tbPass);
            this.groupBox1.Controls.Add(this.ultraLabel2);
            this.groupBox1.Controls.Add(this.tbUser);
            this.groupBox1.Controls.Add(this.ultraLabel4);
            this.groupBox1.Location = new System.Drawing.Point(348, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 219);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // llRegisterTrackmaster
            // 
            this.llRegisterTrackmaster.AutoSize = true;
            this.llRegisterTrackmaster.Location = new System.Drawing.Point(190, 92);
            this.llRegisterTrackmaster.Name = "llRegisterTrackmaster";
            this.llRegisterTrackmaster.Size = new System.Drawing.Size(131, 13);
            this.llRegisterTrackmaster.TabIndex = 20;
            this.llRegisterTrackmaster.TabStop = true;
            this.llRegisterTrackmaster.Text = "No Trackmaster account?";
            this.llRegisterTrackmaster.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRegisterTrackmaster_LinkClicked);
            // 
            // cbCredentials
            // 
            this.cbCredentials.AutoSize = true;
            this.cbCredentials.Location = new System.Drawing.Point(36, 92);
            this.cbCredentials.Name = "cbCredentials";
            this.cbCredentials.Size = new System.Drawing.Size(142, 17);
            this.cbCredentials.TabIndex = 19;
            this.cbCredentials.Text = "Store credentials (if new)";
            this.cbCredentials.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ulInfo1);
            this.groupBox2.Controls.Add(this.ultraLabel1);
            this.groupBox2.Location = new System.Drawing.Point(348, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 214);
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
            // DownloadTrackmasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 684);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvFeedback);
            this.MaximumSize = new System.Drawing.Size(0, 0);
            this.Name = "DownloadTrackmasterForm";
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.uccMeetings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugMeetings)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button btnDownloadTrackmaster;
        private Infragistics.Win.Misc.UltraLabel ulInfo1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private System.Windows.Forms.ListView lvFeedback;
        private System.Windows.Forms.ColumnHeader ch_Time;
        private System.Windows.Forms.ColumnHeader ch_Message;
        private System.Windows.Forms.ColumnHeader ch_Header;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbCredentials;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel llRegisterTrackmaster;
    }
}