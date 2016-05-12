namespace HCM401kAlerter
{
    partial class frmConfiguration
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
            this.btnConfigureEmailPattern = new System.Windows.Forms.Button();
            this.numSmtpPort = new System.Windows.Forms.NumericUpDown();
            this.txtSmtpAddress = new System.Windows.Forms.TextBox();
            this.txtTestEmailAddress = new System.Windows.Forms.TextBox();
            this.txtEmailAccount = new System.Windows.Forms.TextBox();
            this.txtEmailPassword = new System.Windows.Forms.MaskedTextBox();
            this.chkEmailSSL = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pgsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtSunday = new System.Windows.Forms.DateTimePicker();
            this.dtSaturday = new System.Windows.Forms.DateTimePicker();
            this.dtFriday = new System.Windows.Forms.DateTimePicker();
            this.dtThursday = new System.Windows.Forms.DateTimePicker();
            this.dtSingleStartTime = new System.Windows.Forms.DateTimePicker();
            this.chkSingleStartTime = new System.Windows.Forms.CheckBox();
            this.dtWednesday = new System.Windows.Forms.DateTimePicker();
            this.dtTuesday = new System.Windows.Forms.DateTimePicker();
            this.dtMonday = new System.Windows.Forms.DateTimePicker();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.chkFriday = new System.Windows.Forms.CheckBox();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkWednesday = new System.Windows.Forms.CheckBox();
            this.chkTuesday = new System.Windows.Forms.CheckBox();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numRequestBarsCount = new System.Windows.Forms.NumericUpDown();
            this.numAroonOscilatorPeriod = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDataServiceURL = new System.Windows.Forms.TextBox();
            this.txtDataServiceName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDataServicePassword = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCCMail = new System.Windows.Forms.TextBox();
            this.grpMailCredentials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSmtpPort)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRequestBarsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAroonOscilatorPeriod)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMailCredentials
            // 
            this.grpMailCredentials.Controls.Add(this.btnSendTestMail);
            this.grpMailCredentials.Controls.Add(this.btnConfigureEmailPattern);
            this.grpMailCredentials.Controls.Add(this.numSmtpPort);
            this.grpMailCredentials.Controls.Add(this.txtCCMail);
            this.grpMailCredentials.Controls.Add(this.txtSmtpAddress);
            this.grpMailCredentials.Controls.Add(this.txtTestEmailAddress);
            this.grpMailCredentials.Controls.Add(this.txtEmailAccount);
            this.grpMailCredentials.Controls.Add(this.txtEmailPassword);
            this.grpMailCredentials.Controls.Add(this.chkEmailSSL);
            this.grpMailCredentials.Controls.Add(this.label7);
            this.grpMailCredentials.Controls.Add(this.label6);
            this.grpMailCredentials.Controls.Add(this.label5);
            this.grpMailCredentials.Controls.Add(this.label4);
            this.grpMailCredentials.Controls.Add(this.label3);
            this.grpMailCredentials.Controls.Add(this.label2);
            this.grpMailCredentials.Controls.Add(this.label14);
            this.grpMailCredentials.Controls.Add(this.label1);
            this.grpMailCredentials.Location = new System.Drawing.Point(12, 12);
            this.grpMailCredentials.Name = "grpMailCredentials";
            this.grpMailCredentials.Size = new System.Drawing.Size(292, 250);
            this.grpMailCredentials.TabIndex = 0;
            this.grpMailCredentials.TabStop = false;
            this.grpMailCredentials.Text = "Email credentials";
            // 
            // btnSendTestMail
            // 
            this.btnSendTestMail.Location = new System.Drawing.Point(235, 222);
            this.btnSendTestMail.Name = "btnSendTestMail";
            this.btnSendTestMail.Size = new System.Drawing.Size(48, 23);
            this.btnSendTestMail.TabIndex = 14;
            this.btnSendTestMail.Text = "Send";
            this.btnSendTestMail.UseVisualStyleBackColor = true;
            this.btnSendTestMail.Click += new System.EventHandler(this.btnSendTestMail_Click);
            // 
            // btnConfigureEmailPattern
            // 
            this.btnConfigureEmailPattern.Location = new System.Drawing.Point(109, 156);
            this.btnConfigureEmailPattern.Name = "btnConfigureEmailPattern";
            this.btnConfigureEmailPattern.Size = new System.Drawing.Size(75, 23);
            this.btnConfigureEmailPattern.TabIndex = 11;
            this.btnConfigureEmailPattern.Text = "Configure ...";
            this.btnConfigureEmailPattern.UseVisualStyleBackColor = true;
            this.btnConfigureEmailPattern.Click += new System.EventHandler(this.btnConfigureEmailPattern_Click);
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
            // txtSmtpAddress
            // 
            this.txtSmtpAddress.Location = new System.Drawing.Point(109, 27);
            this.txtSmtpAddress.Name = "txtSmtpAddress";
            this.txtSmtpAddress.Size = new System.Drawing.Size(177, 20);
            this.txtSmtpAddress.TabIndex = 1;
            // 
            // txtTestEmailAddress
            // 
            this.txtTestEmailAddress.Location = new System.Drawing.Point(109, 224);
            this.txtTestEmailAddress.Name = "txtTestEmailAddress";
            this.txtTestEmailAddress.Size = new System.Drawing.Size(123, 20);
            this.txtTestEmailAddress.TabIndex = 13;
            // 
            // txtEmailAccount
            // 
            this.txtEmailAccount.Location = new System.Drawing.Point(109, 103);
            this.txtEmailAccount.Name = "txtEmailAccount";
            this.txtEmailAccount.Size = new System.Drawing.Size(177, 20);
            this.txtEmailAccount.TabIndex = 7;
            // 
            // txtEmailPassword
            // 
            this.txtEmailPassword.Location = new System.Drawing.Point(109, 129);
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
            this.label7.Location = new System.Drawing.Point(8, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Test Mail to";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Email Pattern";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Account Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 106);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SMTP Address";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(816, 239);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pgsProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 273);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(903, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pgsProgress
            // 
            this.pgsProgress.Name = "pgsProgress";
            this.pgsProgress.Size = new System.Drawing.Size(100, 16);
            this.pgsProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgsProgress.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtSunday);
            this.groupBox1.Controls.Add(this.dtSaturday);
            this.groupBox1.Controls.Add(this.dtFriday);
            this.groupBox1.Controls.Add(this.dtThursday);
            this.groupBox1.Controls.Add(this.dtSingleStartTime);
            this.groupBox1.Controls.Add(this.chkSingleStartTime);
            this.groupBox1.Controls.Add(this.dtWednesday);
            this.groupBox1.Controls.Add(this.dtTuesday);
            this.groupBox1.Controls.Add(this.dtMonday);
            this.groupBox1.Controls.Add(this.chkSunday);
            this.groupBox1.Controls.Add(this.chkSaturday);
            this.groupBox1.Controls.Add(this.chkFriday);
            this.groupBox1.Controls.Add(this.chkThursday);
            this.groupBox1.Controls.Add(this.chkWednesday);
            this.groupBox1.Controls.Add(this.chkTuesday);
            this.groupBox1.Controls.Add(this.chkMonday);
            this.groupBox1.Location = new System.Drawing.Point(311, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 215);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scheduler settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "______________________";
            // 
            // dtSunday
            // 
            this.dtSunday.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtSunday.Location = new System.Drawing.Point(151, 157);
            this.dtSunday.Name = "dtSunday";
            this.dtSunday.ShowUpDown = true;
            this.dtSunday.Size = new System.Drawing.Size(117, 20);
            this.dtSunday.TabIndex = 13;
            this.dtSunday.Value = new System.DateTime(2012, 3, 15, 18, 0, 0, 0);
            // 
            // dtSaturday
            // 
            this.dtSaturday.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtSaturday.Location = new System.Drawing.Point(151, 134);
            this.dtSaturday.Name = "dtSaturday";
            this.dtSaturday.ShowUpDown = true;
            this.dtSaturday.Size = new System.Drawing.Size(117, 20);
            this.dtSaturday.TabIndex = 11;
            this.dtSaturday.Value = new System.DateTime(2012, 3, 15, 18, 0, 0, 0);
            // 
            // dtFriday
            // 
            this.dtFriday.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtFriday.Location = new System.Drawing.Point(151, 111);
            this.dtFriday.Name = "dtFriday";
            this.dtFriday.ShowUpDown = true;
            this.dtFriday.Size = new System.Drawing.Size(117, 20);
            this.dtFriday.TabIndex = 9;
            this.dtFriday.Value = new System.DateTime(2012, 3, 15, 18, 0, 0, 0);
            // 
            // dtThursday
            // 
            this.dtThursday.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtThursday.Location = new System.Drawing.Point(151, 88);
            this.dtThursday.Name = "dtThursday";
            this.dtThursday.ShowUpDown = true;
            this.dtThursday.Size = new System.Drawing.Size(117, 20);
            this.dtThursday.TabIndex = 7;
            this.dtThursday.Value = new System.DateTime(2012, 3, 15, 18, 0, 0, 0);
            // 
            // dtSingleStartTime
            // 
            this.dtSingleStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtSingleStartTime.Location = new System.Drawing.Point(151, 185);
            this.dtSingleStartTime.Name = "dtSingleStartTime";
            this.dtSingleStartTime.ShowUpDown = true;
            this.dtSingleStartTime.Size = new System.Drawing.Size(117, 20);
            this.dtSingleStartTime.TabIndex = 16;
            this.dtSingleStartTime.Value = new System.DateTime(2012, 3, 15, 18, 0, 0, 0);
            // 
            // chkSingleStartTime
            // 
            this.chkSingleStartTime.AutoSize = true;
            this.chkSingleStartTime.ForeColor = System.Drawing.Color.Green;
            this.chkSingleStartTime.Location = new System.Drawing.Point(16, 187);
            this.chkSingleStartTime.Name = "chkSingleStartTime";
            this.chkSingleStartTime.Size = new System.Drawing.Size(106, 17);
            this.chkSingleStartTime.TabIndex = 15;
            this.chkSingleStartTime.Text = "Single Start Time";
            this.chkSingleStartTime.UseVisualStyleBackColor = true;
            this.chkSingleStartTime.CheckedChanged += new System.EventHandler(this.chkSingleStartTime_CheckedChanged);
            // 
            // dtWednesday
            // 
            this.dtWednesday.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtWednesday.Location = new System.Drawing.Point(151, 65);
            this.dtWednesday.Name = "dtWednesday";
            this.dtWednesday.ShowUpDown = true;
            this.dtWednesday.Size = new System.Drawing.Size(117, 20);
            this.dtWednesday.TabIndex = 5;
            this.dtWednesday.Value = new System.DateTime(2012, 3, 15, 18, 0, 0, 0);
            // 
            // dtTuesday
            // 
            this.dtTuesday.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTuesday.Location = new System.Drawing.Point(151, 42);
            this.dtTuesday.Name = "dtTuesday";
            this.dtTuesday.ShowUpDown = true;
            this.dtTuesday.Size = new System.Drawing.Size(117, 20);
            this.dtTuesday.TabIndex = 3;
            this.dtTuesday.Value = new System.DateTime(2012, 3, 15, 18, 0, 0, 0);
            // 
            // dtMonday
            // 
            this.dtMonday.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtMonday.Location = new System.Drawing.Point(151, 19);
            this.dtMonday.Name = "dtMonday";
            this.dtMonday.ShowUpDown = true;
            this.dtMonday.Size = new System.Drawing.Size(117, 20);
            this.dtMonday.TabIndex = 1;
            this.dtMonday.Value = new System.DateTime(2012, 3, 15, 18, 0, 0, 0);
            // 
            // chkSunday
            // 
            this.chkSunday.AutoSize = true;
            this.chkSunday.ForeColor = System.Drawing.Color.Red;
            this.chkSunday.Location = new System.Drawing.Point(16, 157);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(62, 17);
            this.chkSunday.TabIndex = 12;
            this.chkSunday.Text = "Sunday";
            this.chkSunday.UseVisualStyleBackColor = true;
            // 
            // chkSaturday
            // 
            this.chkSaturday.AutoSize = true;
            this.chkSaturday.ForeColor = System.Drawing.Color.Red;
            this.chkSaturday.Location = new System.Drawing.Point(16, 134);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(68, 17);
            this.chkSaturday.TabIndex = 10;
            this.chkSaturday.Text = "Saturday";
            this.chkSaturday.UseVisualStyleBackColor = true;
            // 
            // chkFriday
            // 
            this.chkFriday.AutoSize = true;
            this.chkFriday.Location = new System.Drawing.Point(16, 111);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(54, 17);
            this.chkFriday.TabIndex = 8;
            this.chkFriday.Text = "Friday";
            this.chkFriday.UseVisualStyleBackColor = true;
            // 
            // chkThursday
            // 
            this.chkThursday.AutoSize = true;
            this.chkThursday.Location = new System.Drawing.Point(16, 88);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(70, 17);
            this.chkThursday.TabIndex = 6;
            this.chkThursday.Text = "Thursday";
            this.chkThursday.UseVisualStyleBackColor = true;
            // 
            // chkWednesday
            // 
            this.chkWednesday.AutoSize = true;
            this.chkWednesday.Location = new System.Drawing.Point(16, 65);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(83, 17);
            this.chkWednesday.TabIndex = 4;
            this.chkWednesday.Text = "Wednesday";
            this.chkWednesday.UseVisualStyleBackColor = true;
            // 
            // chkTuesday
            // 
            this.chkTuesday.AutoSize = true;
            this.chkTuesday.Location = new System.Drawing.Point(16, 42);
            this.chkTuesday.Name = "chkTuesday";
            this.chkTuesday.Size = new System.Drawing.Size(67, 17);
            this.chkTuesday.TabIndex = 2;
            this.chkTuesday.Text = "Tuesday";
            this.chkTuesday.UseVisualStyleBackColor = true;
            // 
            // chkMonday
            // 
            this.chkMonday.AutoSize = true;
            this.chkMonday.Location = new System.Drawing.Point(16, 19);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(64, 17);
            this.chkMonday.TabIndex = 0;
            this.chkMonday.Text = "Monday";
            this.chkMonday.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.numRequestBarsCount);
            this.groupBox2.Controls.Add(this.numAroonOscilatorPeriod);
            this.groupBox2.Location = new System.Drawing.Point(604, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 85);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data settings";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Request Bars min count";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Aroon Oscilator Period";
            // 
            // numRequestBarsCount
            // 
            this.numRequestBarsCount.Location = new System.Drawing.Point(141, 51);
            this.numRequestBarsCount.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numRequestBarsCount.Name = "numRequestBarsCount";
            this.numRequestBarsCount.Size = new System.Drawing.Size(74, 20);
            this.numRequestBarsCount.TabIndex = 3;
            // 
            // numAroonOscilatorPeriod
            // 
            this.numAroonOscilatorPeriod.Location = new System.Drawing.Point(141, 26);
            this.numAroonOscilatorPeriod.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numAroonOscilatorPeriod.Name = "numAroonOscilatorPeriod";
            this.numAroonOscilatorPeriod.Size = new System.Drawing.Size(74, 20);
            this.numAroonOscilatorPeriod.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Data Service URL:";
            // 
            // txtDataServiceURL
            // 
            this.txtDataServiceURL.Location = new System.Drawing.Point(6, 37);
            this.txtDataServiceURL.Name = "txtDataServiceURL";
            this.txtDataServiceURL.Size = new System.Drawing.Size(275, 20);
            this.txtDataServiceURL.TabIndex = 1;
            // 
            // txtDataServiceName
            // 
            this.txtDataServiceName.Location = new System.Drawing.Point(90, 70);
            this.txtDataServiceName.Name = "txtDataServiceName";
            this.txtDataServiceName.Size = new System.Drawing.Size(191, 20);
            this.txtDataServiceName.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Admin Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Admin Password";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtDataServicePassword);
            this.groupBox3.Controls.Add(this.txtDataServiceName);
            this.groupBox3.Controls.Add(this.txtDataServiceURL);
            this.groupBox3.Location = new System.Drawing.Point(604, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 124);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Web service access";
            // 
            // txtDataServicePassword
            // 
            this.txtDataServicePassword.Location = new System.Drawing.Point(90, 97);
            this.txtDataServicePassword.Name = "txtDataServicePassword";
            this.txtDataServicePassword.Size = new System.Drawing.Size(191, 20);
            this.txtDataServicePassword.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 189);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "CC Email Box";
            // 
            // txtCCMail
            // 
            this.txtCCMail.Location = new System.Drawing.Point(109, 186);
            this.txtCCMail.Name = "txtCCMail";
            this.txtCCMail.Size = new System.Drawing.Size(177, 20);
            this.txtCCMail.TabIndex = 1;
            // 
            // frmConfiguration
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 295);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grpMailCredentials);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(919, 333);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(919, 333);
            this.Name = "frmConfiguration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.frmConfiguration_Load);
            this.grpMailCredentials.ResumeLayout(false);
            this.grpMailCredentials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSmtpPort)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRequestBarsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAroonOscilatorPeriod)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMailCredentials;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numSmtpPort;
        private System.Windows.Forms.TextBox txtSmtpAddress;
        private System.Windows.Forms.TextBox txtEmailAccount;
        private System.Windows.Forms.MaskedTextBox txtEmailPassword;
        private System.Windows.Forms.CheckBox chkEmailSSL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConfigureEmailPattern;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSendTestMail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTestEmailAddress;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pgsProgress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSaturday;
        private System.Windows.Forms.CheckBox chkFriday;
        private System.Windows.Forms.CheckBox chkThursday;
        private System.Windows.Forms.CheckBox chkWednesday;
        private System.Windows.Forms.CheckBox chkTuesday;
        private System.Windows.Forms.CheckBox chkMonday;
        private System.Windows.Forms.CheckBox chkSunday;
        private System.Windows.Forms.DateTimePicker dtSingleStartTime;
        private System.Windows.Forms.CheckBox chkSingleStartTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtSunday;
        private System.Windows.Forms.DateTimePicker dtSaturday;
        private System.Windows.Forms.DateTimePicker dtFriday;
        private System.Windows.Forms.DateTimePicker dtThursday;
        private System.Windows.Forms.DateTimePicker dtWednesday;
        private System.Windows.Forms.DateTimePicker dtTuesday;
        private System.Windows.Forms.DateTimePicker dtMonday;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numRequestBarsCount;
        private System.Windows.Forms.NumericUpDown numAroonOscilatorPeriod;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDataServiceURL;
        private System.Windows.Forms.TextBox txtDataServiceName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDataServicePassword;
        private System.Windows.Forms.TextBox txtCCMail;
        private System.Windows.Forms.Label label14;
    }
}