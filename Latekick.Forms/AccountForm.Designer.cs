namespace Latekick.Forms
{
    partial class AccountForm
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
            this.lblUserTitle = new System.Windows.Forms.Label();
            this.txtLKUserName = new System.Windows.Forms.TextBox();
            this.txtLKPassword = new System.Windows.Forms.TextBox();
            this.lblPasswordTitle = new System.Windows.Forms.Label();
            this.txtLKEmail = new System.Windows.Forms.TextBox();
            this.lblEmailAddresstitle = new System.Windows.Forms.Label();
            this.btnSaveLKChanges = new System.Windows.Forms.Button();
            this.lblBalanceTitle = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.btnAddLKFunds = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblBRISUserTitle = new System.Windows.Forms.Label();
            this.txtBRISPassword = new System.Windows.Forms.TextBox();
            this.txtBRISUserName = new System.Windows.Forms.TextBox();
            this.lblBRISPasswordTitle = new System.Windows.Forms.Label();
            this.btnSaveBRISChanges = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTMUserTitle = new System.Windows.Forms.Label();
            this.txtTrackmasterPassword = new System.Windows.Forms.TextBox();
            this.lblTMPasswordTitle = new System.Windows.Forms.Label();
            this.txtTrackmasterUserName = new System.Windows.Forms.TextBox();
            this.btnSaveTrackmasterChanges = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserTitle
            // 
            this.lblUserTitle.Location = new System.Drawing.Point(42, 29);
            this.lblUserTitle.Name = "lblUserTitle";
            this.lblUserTitle.Size = new System.Drawing.Size(100, 28);
            this.lblUserTitle.TabIndex = 0;
            this.lblUserTitle.Text = "Username:";
            this.lblUserTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLKUserName
            // 
            this.txtLKUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLKUserName.Location = new System.Drawing.Point(159, 29);
            this.txtLKUserName.Multiline = true;
            this.txtLKUserName.Name = "txtLKUserName";
            this.txtLKUserName.Size = new System.Drawing.Size(138, 28);
            this.txtLKUserName.TabIndex = 1;
            this.txtLKUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLKPassword
            // 
            this.txtLKPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLKPassword.Location = new System.Drawing.Point(159, 70);
            this.txtLKPassword.Multiline = true;
            this.txtLKPassword.Name = "txtLKPassword";
            this.txtLKPassword.Size = new System.Drawing.Size(138, 28);
            this.txtLKPassword.TabIndex = 3;
            this.txtLKPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPasswordTitle
            // 
            this.lblPasswordTitle.Location = new System.Drawing.Point(42, 70);
            this.lblPasswordTitle.Name = "lblPasswordTitle";
            this.lblPasswordTitle.Size = new System.Drawing.Size(100, 28);
            this.lblPasswordTitle.TabIndex = 2;
            this.lblPasswordTitle.Text = "Password:";
            this.lblPasswordTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLKEmail
            // 
            this.txtLKEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLKEmail.Location = new System.Drawing.Point(159, 110);
            this.txtLKEmail.Multiline = true;
            this.txtLKEmail.Name = "txtLKEmail";
            this.txtLKEmail.ReadOnly = true;
            this.txtLKEmail.Size = new System.Drawing.Size(138, 28);
            this.txtLKEmail.TabIndex = 5;
            this.txtLKEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblEmailAddresstitle
            // 
            this.lblEmailAddresstitle.Location = new System.Drawing.Point(42, 110);
            this.lblEmailAddresstitle.Name = "lblEmailAddresstitle";
            this.lblEmailAddresstitle.Size = new System.Drawing.Size(100, 28);
            this.lblEmailAddresstitle.TabIndex = 4;
            this.lblEmailAddresstitle.Text = "Email address:";
            this.lblEmailAddresstitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSaveLKChanges
            // 
            this.btnSaveLKChanges.Location = new System.Drawing.Point(159, 153);
            this.btnSaveLKChanges.Name = "btnSaveLKChanges";
            this.btnSaveLKChanges.Size = new System.Drawing.Size(138, 28);
            this.btnSaveLKChanges.TabIndex = 6;
            this.btnSaveLKChanges.Text = "Save Changes";
            this.btnSaveLKChanges.UseVisualStyleBackColor = true;
            this.btnSaveLKChanges.Click += new System.EventHandler(this.btnSaveLKChanges_Click);
            // 
            // lblBalanceTitle
            // 
            this.lblBalanceTitle.Location = new System.Drawing.Point(469, 31);
            this.lblBalanceTitle.Name = "lblBalanceTitle";
            this.lblBalanceTitle.Size = new System.Drawing.Size(100, 28);
            this.lblBalanceTitle.TabIndex = 7;
            this.lblBalanceTitle.Text = "Latekick balance:";
            this.lblBalanceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBalance
            // 
            this.lblBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblBalance.Location = new System.Drawing.Point(584, 31);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(138, 28);
            this.lblBalance.TabIndex = 7;
            this.lblBalance.Text = "$ 0";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddLKFunds
            // 
            this.btnAddLKFunds.Location = new System.Drawing.Point(584, 67);
            this.btnAddLKFunds.Name = "btnAddLKFunds";
            this.btnAddLKFunds.Size = new System.Drawing.Size(138, 28);
            this.btnAddLKFunds.TabIndex = 8;
            this.btnAddLKFunds.Text = "Add funds";
            this.btnAddLKFunds.UseVisualStyleBackColor = true;
            this.btnAddLKFunds.Click += new System.EventHandler(this.btnAddFunds_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblUserTitle);
            this.groupBox1.Controls.Add(this.btnAddLKFunds);
            this.groupBox1.Controls.Add(this.txtLKUserName);
            this.groupBox1.Controls.Add(this.lblBalance);
            this.groupBox1.Controls.Add(this.lblPasswordTitle);
            this.groupBox1.Controls.Add(this.lblBalanceTitle);
            this.groupBox1.Controls.Add(this.txtLKPassword);
            this.groupBox1.Controls.Add(this.btnSaveLKChanges);
            this.groupBox1.Controls.Add(this.lblEmailAddresstitle);
            this.groupBox1.Controls.Add(this.txtLKEmail);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 214);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Latekick";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblBRISUserTitle);
            this.groupBox2.Controls.Add(this.txtBRISPassword);
            this.groupBox2.Controls.Add(this.txtBRISUserName);
            this.groupBox2.Controls.Add(this.lblBRISPasswordTitle);
            this.groupBox2.Controls.Add(this.btnSaveBRISChanges);
            this.groupBox2.Location = new System.Drawing.Point(12, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 168);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BRIS";
            // 
            // lblBRISUserTitle
            // 
            this.lblBRISUserTitle.Location = new System.Drawing.Point(36, 37);
            this.lblBRISUserTitle.Name = "lblBRISUserTitle";
            this.lblBRISUserTitle.Size = new System.Drawing.Size(100, 28);
            this.lblBRISUserTitle.TabIndex = 0;
            this.lblBRISUserTitle.Text = "Username:";
            this.lblBRISUserTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBRISPassword
            // 
            this.txtBRISPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBRISPassword.Location = new System.Drawing.Point(144, 78);
            this.txtBRISPassword.Multiline = true;
            this.txtBRISPassword.Name = "txtBRISPassword";
            this.txtBRISPassword.Size = new System.Drawing.Size(138, 28);
            this.txtBRISPassword.TabIndex = 3;
            this.txtBRISPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBRISUserName
            // 
            this.txtBRISUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBRISUserName.Location = new System.Drawing.Point(144, 37);
            this.txtBRISUserName.Multiline = true;
            this.txtBRISUserName.Name = "txtBRISUserName";
            this.txtBRISUserName.Size = new System.Drawing.Size(138, 28);
            this.txtBRISUserName.TabIndex = 1;
            this.txtBRISUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBRISPasswordTitle
            // 
            this.lblBRISPasswordTitle.Location = new System.Drawing.Point(36, 78);
            this.lblBRISPasswordTitle.Name = "lblBRISPasswordTitle";
            this.lblBRISPasswordTitle.Size = new System.Drawing.Size(100, 28);
            this.lblBRISPasswordTitle.TabIndex = 2;
            this.lblBRISPasswordTitle.Text = "Password:";
            this.lblBRISPasswordTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSaveBRISChanges
            // 
            this.btnSaveBRISChanges.Location = new System.Drawing.Point(144, 121);
            this.btnSaveBRISChanges.Name = "btnSaveBRISChanges";
            this.btnSaveBRISChanges.Size = new System.Drawing.Size(138, 28);
            this.btnSaveBRISChanges.TabIndex = 6;
            this.btnSaveBRISChanges.Text = "Save Changes";
            this.btnSaveBRISChanges.UseVisualStyleBackColor = true;
            this.btnSaveBRISChanges.Click += new System.EventHandler(this.btnSaveBRISChanges_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTMUserTitle);
            this.groupBox3.Controls.Add(this.txtTrackmasterPassword);
            this.groupBox3.Controls.Add(this.lblTMPasswordTitle);
            this.groupBox3.Controls.Add(this.txtTrackmasterUserName);
            this.groupBox3.Controls.Add(this.btnSaveTrackmasterChanges);
            this.groupBox3.Location = new System.Drawing.Point(408, 246);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(357, 168);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Trackmaster";
            // 
            // lblTMUserTitle
            // 
            this.lblTMUserTitle.Location = new System.Drawing.Point(37, 37);
            this.lblTMUserTitle.Name = "lblTMUserTitle";
            this.lblTMUserTitle.Size = new System.Drawing.Size(100, 28);
            this.lblTMUserTitle.TabIndex = 0;
            this.lblTMUserTitle.Text = "Username:";
            this.lblTMUserTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTrackmasterPassword
            // 
            this.txtTrackmasterPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrackmasterPassword.Location = new System.Drawing.Point(149, 78);
            this.txtTrackmasterPassword.Multiline = true;
            this.txtTrackmasterPassword.Name = "txtTrackmasterPassword";
            this.txtTrackmasterPassword.Size = new System.Drawing.Size(138, 28);
            this.txtTrackmasterPassword.TabIndex = 3;
            this.txtTrackmasterPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTMPasswordTitle
            // 
            this.lblTMPasswordTitle.Location = new System.Drawing.Point(37, 78);
            this.lblTMPasswordTitle.Name = "lblTMPasswordTitle";
            this.lblTMPasswordTitle.Size = new System.Drawing.Size(100, 28);
            this.lblTMPasswordTitle.TabIndex = 2;
            this.lblTMPasswordTitle.Text = "Password:";
            this.lblTMPasswordTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTrackmasterUserName
            // 
            this.txtTrackmasterUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrackmasterUserName.Location = new System.Drawing.Point(149, 37);
            this.txtTrackmasterUserName.Multiline = true;
            this.txtTrackmasterUserName.Name = "txtTrackmasterUserName";
            this.txtTrackmasterUserName.Size = new System.Drawing.Size(138, 28);
            this.txtTrackmasterUserName.TabIndex = 1;
            this.txtTrackmasterUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSaveTrackmasterChanges
            // 
            this.btnSaveTrackmasterChanges.Location = new System.Drawing.Point(149, 121);
            this.btnSaveTrackmasterChanges.Name = "btnSaveTrackmasterChanges";
            this.btnSaveTrackmasterChanges.Size = new System.Drawing.Size(138, 28);
            this.btnSaveTrackmasterChanges.TabIndex = 6;
            this.btnSaveTrackmasterChanges.Text = "Save Changes";
            this.btnSaveTrackmasterChanges.UseVisualStyleBackColor = true;
            this.btnSaveTrackmasterChanges.Click += new System.EventHandler(this.btnSaveTrackmasterChanges_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 684);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AccountForm";
            this.Text = "Account";
            this.Load += new System.EventHandler(this.Account_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUserTitle;
        private System.Windows.Forms.TextBox txtLKUserName;
        private System.Windows.Forms.TextBox txtLKPassword;
        private System.Windows.Forms.Label lblPasswordTitle;
        private System.Windows.Forms.TextBox txtLKEmail;
        private System.Windows.Forms.Label lblEmailAddresstitle;
        private System.Windows.Forms.Button btnSaveLKChanges;
        private System.Windows.Forms.Label lblBalanceTitle;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Button btnAddLKFunds;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblBRISUserTitle;
        private System.Windows.Forms.TextBox txtBRISPassword;
        private System.Windows.Forms.TextBox txtBRISUserName;
        private System.Windows.Forms.Label lblBRISPasswordTitle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSaveBRISChanges;
        private System.Windows.Forms.Label lblTMUserTitle;
        private System.Windows.Forms.TextBox txtTrackmasterPassword;
        private System.Windows.Forms.Label lblTMPasswordTitle;
        private System.Windows.Forms.TextBox txtTrackmasterUserName;
        private System.Windows.Forms.Button btnSaveTrackmasterChanges;
    }
}