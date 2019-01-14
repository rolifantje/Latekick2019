namespace Latekick.Forms
{
    partial class ConvertForm : MDIBase
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
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
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
            this.button1 = new System.Windows.Forms.Button();
            this.ugBRISMeetings = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.uccMeetings = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblDate = new Infragistics.Win.Misc.UltraLabel();
            this.lvFeedback = new System.Windows.Forms.ListView();
            this.ch_Header = new System.Windows.Forms.ColumnHeader();
            this.ch_Time = new System.Windows.Forms.ColumnHeader();
            this.ch_Message = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbTrackmaster = new System.Windows.Forms.PictureBox();
            this.pbBRIS = new System.Windows.Forms.PictureBox();
            this.ugTrackmasterMeetings = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbCredentials = new System.Windows.Forms.CheckBox();
            this.tbLKPass = new System.Windows.Forms.TextBox();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tbLKUser = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ugBRISMeetings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccMeetings)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrackmaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBRIS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugTrackmasterMeetings)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(18, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(289, 68);
            this.button1.TabIndex = 0;
            this.button1.Text = "Extract Latekick numbers + Generate PDF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ugBRISMeetings
            // 
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            appearance15.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugBRISMeetings.DisplayLayout.Appearance = appearance15;
            this.ugBRISMeetings.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugBRISMeetings.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance16.BorderColor = System.Drawing.SystemColors.Window;
            this.ugBRISMeetings.DisplayLayout.GroupByBox.Appearance = appearance16;
            appearance17.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugBRISMeetings.DisplayLayout.GroupByBox.BandLabelAppearance = appearance17;
            this.ugBRISMeetings.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugBRISMeetings.DisplayLayout.GroupByBox.Hidden = true;
            appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance18.BackColor2 = System.Drawing.SystemColors.Control;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance18.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugBRISMeetings.DisplayLayout.GroupByBox.PromptAppearance = appearance18;
            this.ugBRISMeetings.DisplayLayout.MaxColScrollRegions = 1;
            this.ugBRISMeetings.DisplayLayout.MaxRowScrollRegions = 1;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugBRISMeetings.DisplayLayout.Override.ActiveCellAppearance = appearance19;
            appearance20.BackColor = System.Drawing.SystemColors.Highlight;
            appearance20.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugBRISMeetings.DisplayLayout.Override.ActiveRowAppearance = appearance20;
            this.ugBRISMeetings.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.ugBRISMeetings.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugBRISMeetings.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            this.ugBRISMeetings.DisplayLayout.Override.CardAreaAppearance = appearance21;
            appearance22.BorderColor = System.Drawing.Color.Silver;
            appearance22.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugBRISMeetings.DisplayLayout.Override.CellAppearance = appearance22;
            this.ugBRISMeetings.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.ugBRISMeetings.DisplayLayout.Override.CellPadding = 0;
            appearance23.BackColor = System.Drawing.SystemColors.Control;
            appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance23.BorderColor = System.Drawing.SystemColors.Window;
            this.ugBRISMeetings.DisplayLayout.Override.GroupByRowAppearance = appearance23;
            appearance24.TextHAlignAsString = "Left";
            this.ugBRISMeetings.DisplayLayout.Override.HeaderAppearance = appearance24;
            this.ugBRISMeetings.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugBRISMeetings.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance25.BackColor = System.Drawing.SystemColors.Window;
            appearance25.BorderColor = System.Drawing.Color.Silver;
            this.ugBRISMeetings.DisplayLayout.Override.RowAppearance = appearance25;
            this.ugBRISMeetings.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.ugBRISMeetings.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance26.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugBRISMeetings.DisplayLayout.Override.TemplateAddRowAppearance = appearance26;
            this.ugBRISMeetings.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugBRISMeetings.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugBRISMeetings.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugBRISMeetings.Location = new System.Drawing.Point(16, 118);
            this.ugBRISMeetings.Name = "ugBRISMeetings";
            this.ugBRISMeetings.Size = new System.Drawing.Size(442, 294);
            this.ugBRISMeetings.TabIndex = 12;
            this.ugBRISMeetings.Text = "ultraGrid1";
            // 
            // uccMeetings
            // 
            appearance27.FontData.SizeInPoints = 10F;
            this.uccMeetings.Appearance = appearance27;
            appearance28.TextHAlignAsString = "Center";
            this.uccMeetings.DateButtonAppearance = appearance28;
            appearance29.TextHAlignAsString = "Center";
            this.uccMeetings.DateButtonAreaAppearance = appearance29;
            this.uccMeetings.DateButtons.Add(dateButton1);
            this.uccMeetings.Location = new System.Drawing.Point(152, 18);
            this.uccMeetings.MaximumSize = new System.Drawing.Size(250, 32);
            this.uccMeetings.MinimumDaySize = new System.Drawing.Size(32, 32);
            this.uccMeetings.MinimumSize = new System.Drawing.Size(150, 32);
            appearance14.TextHAlignAsString = "Center";
            this.uccMeetings.MonthPopupAppearance = appearance14;
            this.uccMeetings.Name = "uccMeetings";
            this.uccMeetings.NonAutoSizeHeight = 21;
            this.uccMeetings.OverrideFontSettings = false;
            this.uccMeetings.Size = new System.Drawing.Size(150, 21);
            this.uccMeetings.TabIndex = 10;
            this.uccMeetings.Value = "";
            this.uccMeetings.ValueChanged += new System.EventHandler(this.uccMeetings_ValueChanged);
            // 
            // lblDate
            // 
            appearance11.FontData.BoldAsString = "True";
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.lblDate.Appearance = appearance11;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(16, 18);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(105, 32);
            this.lblDate.TabIndex = 11;
            this.lblDate.Text = "Select a date:";
            // 
            // lvFeedback
            // 
            this.lvFeedback.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Header,
            this.ch_Time,
            this.ch_Message});
            this.lvFeedback.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvFeedback.Location = new System.Drawing.Point(0, 581);
            this.lvFeedback.Name = "lvFeedback";
            this.lvFeedback.Size = new System.Drawing.Size(1293, 207);
            this.lvFeedback.TabIndex = 16;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbTrackmaster);
            this.groupBox1.Controls.Add(this.pbBRIS);
            this.groupBox1.Controls.Add(this.ugTrackmasterMeetings);
            this.groupBox1.Controls.Add(this.ugBRISMeetings);
            this.groupBox1.Location = new System.Drawing.Point(400, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 431);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // pbTrackmaster
            // 
            this.pbTrackmaster.Image = global::Latekick.Forms.Properties.Resources.Trackmaster;
            this.pbTrackmaster.Location = new System.Drawing.Point(590, 15);
            this.pbTrackmaster.Name = "pbTrackmaster";
            this.pbTrackmaster.Size = new System.Drawing.Size(159, 84);
            this.pbTrackmaster.TabIndex = 15;
            this.pbTrackmaster.TabStop = false;
            this.pbTrackmaster.Click += new System.EventHandler(this.pbTrackmaster_Click);
            // 
            // pbBRIS
            // 
            this.pbBRIS.Image = global::Latekick.Forms.Properties.Resources.brisnet;
            this.pbBRIS.Location = new System.Drawing.Point(16, 34);
            this.pbBRIS.Name = "pbBRIS";
            this.pbBRIS.Size = new System.Drawing.Size(442, 65);
            this.pbBRIS.TabIndex = 14;
            this.pbBRIS.TabStop = false;
            this.pbBRIS.Click += new System.EventHandler(this.pbBRIS_Click);
            // 
            // ugTrackmasterMeetings
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ugTrackmasterMeetings.DisplayLayout.Appearance = appearance1;
            this.ugTrackmasterMeetings.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugTrackmasterMeetings.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.ugTrackmasterMeetings.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugTrackmasterMeetings.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.ugTrackmasterMeetings.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ugTrackmasterMeetings.DisplayLayout.GroupByBox.Hidden = true;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ugTrackmasterMeetings.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.ugTrackmasterMeetings.DisplayLayout.MaxColScrollRegions = 1;
            this.ugTrackmasterMeetings.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ugTrackmasterMeetings.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ugTrackmasterMeetings.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.ugTrackmasterMeetings.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.ugTrackmasterMeetings.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ugTrackmasterMeetings.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.ugTrackmasterMeetings.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ugTrackmasterMeetings.DisplayLayout.Override.CellAppearance = appearance8;
            this.ugTrackmasterMeetings.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.ugTrackmasterMeetings.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.ugTrackmasterMeetings.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.ugTrackmasterMeetings.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.ugTrackmasterMeetings.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ugTrackmasterMeetings.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.ugTrackmasterMeetings.DisplayLayout.Override.RowAppearance = appearance12;
            this.ugTrackmasterMeetings.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.ugTrackmasterMeetings.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ugTrackmasterMeetings.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.ugTrackmasterMeetings.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ugTrackmasterMeetings.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ugTrackmasterMeetings.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ugTrackmasterMeetings.Location = new System.Drawing.Point(486, 118);
            this.ugTrackmasterMeetings.Name = "ugTrackmasterMeetings";
            this.ugTrackmasterMeetings.Size = new System.Drawing.Size(370, 294);
            this.ugTrackmasterMeetings.TabIndex = 13;
            this.ugTrackmasterMeetings.Text = "ultraGrid1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.cbCredentials);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.tbLKPass);
            this.groupBox2.Controls.Add(this.ultraLabel4);
            this.groupBox2.Controls.Add(this.ultraLabel2);
            this.groupBox2.Controls.Add(this.tbLKUser);
            this.groupBox2.Location = new System.Drawing.Point(13, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 262);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(44, 228);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(243, 13);
            this.linkLabel1.TabIndex = 25;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Click here if you don\'t have a username/password";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cbCredentials
            // 
            this.cbCredentials.AutoSize = true;
            this.cbCredentials.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCredentials.Location = new System.Drawing.Point(18, 79);
            this.cbCredentials.Name = "cbCredentials";
            this.cbCredentials.Size = new System.Drawing.Size(185, 18);
            this.cbCredentials.TabIndex = 24;
            this.cbCredentials.Text = "Store credentials (if new)";
            this.cbCredentials.UseVisualStyleBackColor = true;
            // 
            // tbLKPass
            // 
            this.tbLKPass.Enabled = false;
            this.tbLKPass.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLKPass.Location = new System.Drawing.Point(185, 51);
            this.tbLKPass.Name = "tbLKPass";
            this.tbLKPass.PasswordChar = '*';
            this.tbLKPass.Size = new System.Drawing.Size(118, 22);
            this.tbLKPass.TabIndex = 23;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel4.Location = new System.Drawing.Point(18, 51);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(145, 19);
            this.ultraLabel4.TabIndex = 21;
            this.ultraLabel4.Text = "Latekick password:";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(18, 26);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(145, 19);
            this.ultraLabel2.TabIndex = 20;
            this.ultraLabel2.Text = "Latekick username:";
            // 
            // tbLKUser
            // 
            this.tbLKUser.Enabled = false;
            this.tbLKUser.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLKUser.Location = new System.Drawing.Point(185, 26);
            this.tbLKUser.Name = "tbLKUser";
            this.tbLKUser.Size = new System.Drawing.Size(118, 22);
            this.tbLKUser.TabIndex = 22;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblDate);
            this.groupBox3.Controls.Add(this.uccMeetings);
            this.groupBox3.Location = new System.Drawing.Point(15, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 64);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // ConvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 788);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvFeedback);
            this.MaximumSize = new System.Drawing.Size(0, 0);
            this.Name = "ConvertForm";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.ugBRISMeetings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccMeetings)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTrackmaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBRIS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugTrackmasterMeetings)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugBRISMeetings;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccMeetings;
        private Infragistics.Win.Misc.UltraLabel lblDate;
        private System.Windows.Forms.ListView lvFeedback;
        private System.Windows.Forms.ColumnHeader ch_Header;
        private System.Windows.Forms.ColumnHeader ch_Time;
        private System.Windows.Forms.ColumnHeader ch_Message;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbCredentials;
        private System.Windows.Forms.TextBox tbLKPass;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private System.Windows.Forms.TextBox tbLKUser;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugTrackmasterMeetings;
        private System.Windows.Forms.PictureBox pbBRIS;
        private System.Windows.Forms.PictureBox pbTrackmaster;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}