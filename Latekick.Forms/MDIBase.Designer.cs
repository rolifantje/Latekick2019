namespace Latekick.Forms
{
    partial class MDIBase
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
            this.SuspendLayout();
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1144, 422);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1276, 712);
            this.Name = "FormBase";
            this.Text = "BaseWindow";
            this.Load += new System.EventHandler(this.MDIBase_Load);
            this.SizeChanged += new System.EventHandler(this.LatekickContentForm_SizeChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LatekickContentForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion
    }
}