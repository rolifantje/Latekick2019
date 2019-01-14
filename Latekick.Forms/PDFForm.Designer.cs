namespace Latekick.Forms
{
    partial class PDFForm
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
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.ugMeetings = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.uccMeetings = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblDate = new Infragistics.Win.Misc.UltraLabel();
            this.btnViewPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ugMeetings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccMeetings)).BeginInit();
            this.SuspendLayout();
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
            this.ugMeetings.Location = new System.Drawing.Point(12, 93);
            this.ugMeetings.Name = "ugMeetings";
            this.ugMeetings.Size = new System.Drawing.Size(298, 396);
            this.ugMeetings.TabIndex = 16;
            this.ugMeetings.Text = "ultraGrid1";
            // 
            // uccMeetings
            // 
            this.uccMeetings.DateButtons.Add(dateButton1);
            this.uccMeetings.Location = new System.Drawing.Point(189, 66);
            this.uccMeetings.MinimumDaySize = new System.Drawing.Size(25, 25);
            appearance14.TextHAlignAsString = "Center";
            this.uccMeetings.MonthPopupAppearance = appearance14;
            this.uccMeetings.Name = "uccMeetings";
            this.uccMeetings.NonAutoSizeHeight = 21;
            this.uccMeetings.Size = new System.Drawing.Size(121, 21);
            this.uccMeetings.TabIndex = 14;
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
            this.lblDate.Location = new System.Drawing.Point(12, 66);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(160, 21);
            this.lblDate.TabIndex = 15;
            this.lblDate.Text = "Select a date:";
            // 
            // btnViewPDF
            // 
            this.btnViewPDF.Location = new System.Drawing.Point(12, 495);
            this.btnViewPDF.Name = "btnViewPDF";
            this.btnViewPDF.Size = new System.Drawing.Size(298, 68);
            this.btnViewPDF.TabIndex = 13;
            this.btnViewPDF.Text = "View PDF";
            this.btnViewPDF.UseVisualStyleBackColor = true;
            this.btnViewPDF.Click += new System.EventHandler(this.btnViewPDF_Click);
            // 
            // PDFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 684);
            this.Controls.Add(this.ugMeetings);
            this.Controls.Add(this.uccMeetings);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnViewPDF);
            this.MaximumSize = new System.Drawing.Size(0, 0);
            this.Name = "PDFForm";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.ugMeetings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccMeetings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid ugMeetings;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccMeetings;
        private Infragistics.Win.Misc.UltraLabel lblDate;
        private System.Windows.Forms.Button btnViewPDF;


    }
}