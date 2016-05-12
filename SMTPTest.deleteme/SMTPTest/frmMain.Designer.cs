namespace SMTPTest
{
    partial class frmMain
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
            this.grpMailCredentials = new System.Windows.Forms.GroupBox();
            this.btnSendTestMail = new System.Windows.Forms.Button();
            this.numSmtpPort = new System.Windows.Forms.NumericUpDown();
            this.txtCCMail = new System.Windows.Forms.TextBox();
            this.txtSmtpAddress = new System.Windows.Forms.TextBox();
            this.txtTestEmailAddress = new System.Windows.Forms.TextBox();
            this.txtEmailAccount = new System.Windows.Forms.TextBox();
            this.txtEmailPassword = new System.Windows.Forms.MaskedTextBox();
            this.chkEmailSSL = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmailPattern = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.pgsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmailFrom = new System.Windows.Forms.TextBox();
            this.grpMailCredentials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSmtpPort)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMailCredentials
            // 
            this.grpMailCredentials.Controls.Add(this.txtEmailPattern);
            this.grpMailCredentials.Controls.Add(this.btnSendTestMail);
            this.grpMailCredentials.Controls.Add(this.numSmtpPort);
            this.grpMailCredentials.Controls.Add(this.txtCCMail);
            this.grpMailCredentials.Controls.Add(this.txtSmtpAddress);
            this.grpMailCredentials.Controls.Add(this.txtTestEmailAddress);
            this.grpMailCredentials.Controls.Add(this.txtEmailFrom);
            this.grpMailCredentials.Controls.Add(this.txtEmailAccount);
            this.grpMailCredentials.Controls.Add(this.txtEmailPassword);
            this.grpMailCredentials.Controls.Add(this.chkEmailSSL);
            this.grpMailCredentials.Controls.Add(this.label7);
            this.grpMailCredentials.Controls.Add(this.label6);
            this.grpMailCredentials.Controls.Add(this.label5);
            this.grpMailCredentials.Controls.Add(this.label8);
            this.grpMailCredentials.Controls.Add(this.label4);
            this.grpMailCredentials.Controls.Add(this.label3);
            this.grpMailCredentials.Controls.Add(this.label2);
            this.grpMailCredentials.Controls.Add(this.label14);
            this.grpMailCredentials.Controls.Add(this.label1);
            this.grpMailCredentials.Location = new System.Drawing.Point(12, 12);
            this.grpMailCredentials.Name = "grpMailCredentials";
            this.grpMailCredentials.Size = new System.Drawing.Size(292, 415);
            this.grpMailCredentials.TabIndex = 1;
            this.grpMailCredentials.TabStop = false;
            this.grpMailCredentials.Text = "Email credentials";
            // 
            // btnSendTestMail
            // 
            this.btnSendTestMail.Location = new System.Drawing.Point(234, 384);
            this.btnSendTestMail.Name = "btnSendTestMail";
            this.btnSendTestMail.Size = new System.Drawing.Size(48, 23);
            this.btnSendTestMail.TabIndex = 14;
            this.btnSendTestMail.Text = "Send";
            this.btnSendTestMail.UseVisualStyleBackColor = true;
            this.btnSendTestMail.Click += new System.EventHandler(this.btnSendTestMail_Click);
            // 
            // numSmtpPort
            // 
            this.numSmtpPort.Location = new System.Drawing.Point(109, 54);
            this.numSmtpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numSmtpPort.Name = "numSmtpPort";
            this.numSmtpPort.Size = new System.Drawing.Size(80, 20);
            this.numSmtpPort.TabIndex = 3;
            // 
            // txtCCMail
            // 
            this.txtCCMail.Location = new System.Drawing.Point(108, 348);
            this.txtCCMail.Name = "txtCCMail";
            this.txtCCMail.Size = new System.Drawing.Size(177, 20);
            this.txtCCMail.TabIndex = 1;
            // 
            // txtSmtpAddress
            // 
            this.txtSmtpAddress.Location = new System.Drawing.Point(109, 27);
            this.txtSmtpAddress.Name = "txtSmtpAddress";
            this.txtSmtpAddress.Size = new System.Drawing.Size(177, 20);
            this.txtSmtpAddress.TabIndex = 1;
            // 
            // txtTestEmailAddress
            // 
            this.txtTestEmailAddress.Location = new System.Drawing.Point(108, 386);
            this.txtTestEmailAddress.Name = "txtTestEmailAddress";
            this.txtTestEmailAddress.Size = new System.Drawing.Size(123, 20);
            this.txtTestEmailAddress.TabIndex = 13;
            // 
            // txtEmailAccount
            // 
            this.txtEmailAccount.Location = new System.Drawing.Point(109, 134);
            this.txtEmailAccount.Name = "txtEmailAccount";
            this.txtEmailAccount.Size = new System.Drawing.Size(177, 20);
            this.txtEmailAccount.TabIndex = 7;
            // 
            // txtEmailPassword
            // 
            this.txtEmailPassword.Location = new System.Drawing.Point(109, 160);
            this.txtEmailPassword.Name = "txtEmailPassword";
            this.txtEmailPassword.PasswordChar = '●';
            this.txtEmailPassword.Size = new System.Drawing.Size(177, 20);
            this.txtEmailPassword.TabIndex = 9;
            // 
            // chkEmailSSL
            // 
            this.chkEmailSSL.AutoSize = true;
            this.chkEmailSSL.Location = new System.Drawing.Point(109, 81);
            this.chkEmailSSL.Name = "chkEmailSSL";
            this.chkEmailSSL.Size = new System.Drawing.Size(75, 17);
            this.chkEmailSSL.TabIndex = 5;
            this.chkEmailSSL.Text = "(Yes / No)";
            this.chkEmailSSL.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Test Mail to";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Account Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Account Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "SSL Enabled";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SMPT Port";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 351);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "CC Email Box";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SMTP Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Email Pattern";
            // 
            // txtEmailPattern
            // 
            this.txtEmailPattern.Location = new System.Drawing.Point(12, 206);
            this.txtEmailPattern.Multiline = true;
            this.txtEmailPattern.Name = "txtEmailPattern";
            this.txtEmailPattern.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmailPattern.Size = new System.Drawing.Size(273, 136);
            this.txtEmailPattern.TabIndex = 15;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessage,
            this.pgsProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 491);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(314, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(39, 17);
            this.lblMessage.Text = "Ready";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(108, 448);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pgsProgress
            // 
            this.pgsProgress.Name = "pgsProgress";
            this.pgsProgress.Size = new System.Drawing.Size(100, 16);
            this.pgsProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgsProgress.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Email from";
            // 
            // txtEmailFrom
            // 
            this.txtEmailFrom.Location = new System.Drawing.Point(109, 108);
            this.txtEmailFrom.Name = "txtEmailFrom";
            this.txtEmailFrom.Size = new System.Drawing.Size(177, 20);
            this.txtEmailFrom.TabIndex = 7;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 513);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpMailCredentials);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMTP Test";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpMailCredentials.ResumeLayout(false);
            this.grpMailCredentials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSmtpPort)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMailCredentials;
        private System.Windows.Forms.TextBox txtEmailPattern;
        private System.Windows.Forms.Button btnSendTestMail;
        private System.Windows.Forms.NumericUpDown numSmtpPort;
        private System.Windows.Forms.TextBox txtCCMail;
        private System.Windows.Forms.TextBox txtSmtpAddress;
        private System.Windows.Forms.TextBox txtTestEmailAddress;
        private System.Windows.Forms.TextBox txtEmailAccount;
        private System.Windows.Forms.MaskedTextBox txtEmailPassword;
        private System.Windows.Forms.CheckBox chkEmailSSL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripProgressBar pgsProgress;
        private System.Windows.Forms.TextBox txtEmailFrom;
        private System.Windows.Forms.Label label8;
    }
}

