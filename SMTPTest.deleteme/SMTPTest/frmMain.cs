using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMTPTest
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtSmtpAddress.Text = Configuration.MailSMTP;
            numSmtpPort.Value = Configuration.MailSMTPPort;
            chkEmailSSL.Checked = Configuration.MailSMTPSSL;
            txtEmailAccount.Text = Configuration.MailAccountAddress;
            txtEmailPassword.Text = Configuration.MailPassword;
            txtTestEmailAddress.Text = Configuration.MailTestAddress;
            txtCCMail.Text = Configuration.CCMail;
            txtEmailPattern.Text = Configuration.MailPattern;
            txtEmailFrom.Text = Configuration.EmailFrom;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
        }

        private void btnSendTestMail_Click(object sender, EventArgs e)
        {
            pgsProgress.Visible = true;
            grpMailCredentials.Enabled = false;
            btnSave.Enabled = false;
            lblMessage.Text = "progress";
            SaveConfiguration();
            SendTestMail(Configuration.MailTestAddress, Configuration.MailSubject, Configuration.MailPattern);
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
            Configuration.MailPattern = txtEmailPattern.Text.Trim();
            Configuration.EmailFrom = txtEmailFrom.Text.Trim();
        }


        public delegate void SendTestMailDelegate(string recepientEmail, string subject, string content);
        public void SendTestMail(string recepientEmail, string subject, string content)
        {
            SendTestMailDelegate dlg = new SendTestMailDelegate(InnerSendTestMail);
            dlg.BeginInvoke(recepientEmail, subject, content, new AsyncCallback(SendTestMailDone), dlg);
        }
        private void SendTestMailDone(IAsyncResult result)
        {
            ((SendTestMailDelegate)result.AsyncState).EndInvoke(result);
        }
        private void InnerSendTestMail(string recepientEmail, string subject, string content)
        {
            var result = EmailSender.SendEmail(recepientEmail, subject, content);
            OnSendTestMailComplete(result);
        }

        private delegate void OnSendTestMailCompleteDelegate(SendMailResult result);

        private void OnSendTestMailComplete(SendMailResult result)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new OnSendTestMailCompleteDelegate(OnSendTestMailComplete), result);
                return;
            }
            if (result.Complete)
            {
                MessageBox.Show("Message was sent", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblMessage.Text = "Done";
            }
            else
            {
                lblMessage.Text = "Error";
                if (result.InternalError)
                    MessageBox.Show("Message wasn't sent. Reason messgae:\r\n" + result.InternalErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Message wasn't sent. Reason unknown", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pgsProgress.Visible = false;
            grpMailCredentials.Enabled = true;
            btnSave.Enabled = true;
        }
    }
}
