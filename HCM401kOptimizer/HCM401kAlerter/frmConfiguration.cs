using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HCM401kAlerter
{
    public partial class frmConfiguration : Form
    {
        public frmConfiguration()
        {
            InitializeComponent();
        }

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            txtSmtpAddress.Text = Configuration.MailSMTP;
            numSmtpPort.Value = Configuration.MailSMTPPort;
            chkEmailSSL.Checked = Configuration.MailSMTPSSL;
            txtEmailAccount.Text = Configuration.MailAccountAddress;
            txtEmailPassword.Text = Configuration.MailPassword;
            txtTestEmailAddress.Text = Configuration.MailTestAddress;
            txtCCMail.Text = Configuration.CCMail;

            chkMonday.Checked = Configuration.chkMonday;
            chkTuesday.Checked = Configuration.chkTuesday;
            chkWednesday.Checked = Configuration.chkWednesday;
            chkThursday.Checked = Configuration.chkThursday;
            chkFriday.Checked = Configuration.chkFriday;
            chkSaturday.Checked = Configuration.chkSaturday;
            chkSunday.Checked = Configuration.chkSunday;
            chkSingleStartTime.Checked = Configuration.chkSingleStartTime;

            dtMonday.Value = Configuration.dtMonday;
            dtTuesday.Value = Configuration.dtTuesday;
            dtWednesday.Value = Configuration.dtWednesday;
            dtThursday.Value = Configuration.dtThursday;
            dtFriday.Value = Configuration.dtFriday;
            dtSaturday.Value = Configuration.dtSaturday;
            dtSunday.Value = Configuration.dtSunday;
            dtSingleStartTime.Value = Configuration.dtSingleStartTime;

            numAroonOscilatorPeriod.Value = Configuration.AroonOscilatorPeriod;
            numRequestBarsCount.Value = Configuration.RequestBarsCount;

            txtDataServiceURL.Text = Configuration.DataServiceURL;
            txtDataServiceName.Text = Configuration.DataServiceName;
            txtDataServicePassword.Text = Configuration.DataServicePassword;

            CheckChecks();
        }

        private void btnConfigureEmailPattern_Click(object sender, EventArgs e)
        {
            frmMailPattern ptrn = new frmMailPattern();
            ptrn.ShowDialog(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnSendTestMail_Click(object sender, EventArgs e)
        {
            pgsProgress.Visible = true;
            grpMailCredentials.Enabled = false;
            btnOk.Enabled = false;
            SaveConfiguration();
            SendTestMail(Configuration.MailTestAddress, Configuration.MailSubject, Configuration.MailPattern);
        }

        public delegate void SendTestMailDelegate(string recepientEmail, string subject, string content);
        public void SendTestMail(string recepientEmail, string subject, string content)
        {
            SendTestMailDelegate dlg = new SendTestMailDelegate(InnerSendTestMail);
            dlg.BeginInvoke(recepientEmail, subject, content, new AsyncCallback(UpdateStockScannerDone), dlg);
        }
        private void UpdateStockScannerDone(IAsyncResult result)
        {
            ((SendTestMailDelegate)result.AsyncState).EndInvoke(result);
        }
        private void InnerSendTestMail(string recepientEmail, string subject, string content)
        {
            var result = EmailSender.SendEmail(recepientEmail, subject, content);
            OnUpdateStockScannerComplete(result);
        }

        private delegate void OnUpdateStockScannerCompleteDelegate(SendMailResult result);

        private void OnUpdateStockScannerComplete(SendMailResult result)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new OnUpdateStockScannerCompleteDelegate(OnUpdateStockScannerComplete), result);
                return;
            }
            if (result.Complete)
                MessageBox.Show("Message was sent", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                if (result.InternalError)
                    MessageBox.Show("Message wasn't sent. Reason messgae:\r\n" + result.InternalErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Message wasn't sent. Reason unknown", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            pgsProgress.Visible = false;
            grpMailCredentials.Enabled = true;
            btnOk.Enabled = true;
        }


        private void SaveConfiguration()
        {
            Configuration.MailSMTP = txtSmtpAddress.Text.Trim();
            Configuration.MailSMTPPort = (int)numSmtpPort.Value;
            Configuration.MailSMTPSSL = chkEmailSSL.Checked;
            Configuration.MailAccountAddress = txtEmailAccount.Text.Trim();
            Configuration.MailPassword = txtEmailPassword.Text;
            Configuration.MailTestAddress = txtTestEmailAddress.Text.Trim();
            Configuration.CCMail = txtCCMail.Text.Trim();

            Configuration.chkMonday = chkMonday.Checked;
            Configuration.chkTuesday = chkTuesday.Checked;
            Configuration.chkWednesday = chkWednesday.Checked;
            Configuration.chkThursday = chkThursday.Checked;
            Configuration.chkFriday = chkFriday.Checked;
            Configuration.chkSaturday = chkSaturday.Checked;
            Configuration.chkSunday = chkSunday.Checked;
            Configuration.chkSingleStartTime = chkSingleStartTime.Checked;

            Configuration.dtMonday = dtMonday.Value;
            Configuration.dtTuesday = dtTuesday.Value;
            Configuration.dtWednesday = dtWednesday.Value;
            Configuration.dtThursday = dtThursday.Value;
            Configuration.dtFriday = dtFriday.Value;
            Configuration.dtSaturday = dtSaturday.Value;
            Configuration.dtSunday = dtSunday.Value;
            Configuration.dtSingleStartTime = dtSingleStartTime.Value;

            Configuration.AroonOscilatorPeriod = (int)numAroonOscilatorPeriod.Value;
            Configuration.RequestBarsCount = (int)numRequestBarsCount.Value;
            Configuration.DataServiceURL = txtDataServiceURL.Text.Trim();
            Configuration.DataServiceName = txtDataServiceName.Text;
            Configuration.DataServicePassword = txtDataServicePassword.Text;
        }

        private void chkSingleStartTime_CheckedChanged(object sender, EventArgs e)
        {
            CheckChecks();
        }

        private void CheckChecks()
        {
            dtMonday.Enabled = !chkSingleStartTime.Checked;
            dtTuesday.Enabled = !chkSingleStartTime.Checked;
            dtWednesday.Enabled = !chkSingleStartTime.Checked;
            dtThursday.Enabled = !chkSingleStartTime.Checked;
            dtFriday.Enabled = !chkSingleStartTime.Checked;
            dtSaturday.Enabled = !chkSingleStartTime.Checked;
            dtSunday.Enabled = !chkSingleStartTime.Checked;
            dtSingleStartTime.Enabled = chkSingleStartTime.Checked;
        }

    }
}
