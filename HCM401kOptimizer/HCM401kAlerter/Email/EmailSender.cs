using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace HCM401kAlerter
{
    public static class EmailSender
    {
        public static SendMailResult SendEmail(string recepientEmail, string subject, string content, ConfigSnapShot config = null)
        {
            string MailSMTP;
            int MailSMTPPort;
            bool MailSMTPSSL;
            string MailAccountAddress;
            string MailPassword;
            string CCMail = string.Empty;
            if (config != null)
            {
                MailSMTP = config.MailSMTP;
                MailSMTPPort = config.MailSMTPPort;
                MailSMTPSSL = config.MailSMTPSSL;
                MailAccountAddress = config.MailAccountAddress;
                MailPassword = config.MailPassword;
                CCMail = config.CCMail;
            }
            else
            {
                MailSMTP = Configuration.MailSMTP;
                MailSMTPPort = Configuration.MailSMTPPort;
                MailSMTPSSL = Configuration.MailSMTPSSL;
                MailAccountAddress = Configuration.MailAccountAddress;
                MailPassword = Configuration.MailPassword;
                CCMail = Configuration.CCMail;
            }


            SendMailResult ret = new SendMailResult();
            try
            {
                MailMessage message = new MailMessage();
                message.To.Clear();
                message.To.Add(recepientEmail);
                if (!string.IsNullOrEmpty(CCMail))
                {
                    message.CC.Clear();
                    message.CC.Add(CCMail);
                }
                message.Headers.Add("Message-ID", "<" + message.GetHashCode() + ".MAI@" + MailSMTP + ">");
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.From = new System.Net.Mail.MailAddress(MailAccountAddress);
                message.Subject = subject;
                AlternateView plainView = AlternateView.CreateAlternateViewFromString("", null, "text/plain");
                message.AlternateViews.Add(plainView);
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(content, System.Text.Encoding.UTF8, "text/html");
                message.AlternateViews.Add(htmlView);
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(MailSMTP, MailSMTPPort);
                client.EnableSsl = MailSMTPSSL;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Timeout = 10000;
                client.Credentials = new System.Net.NetworkCredential(MailAccountAddress, MailPassword);
                client.Send(message);
                ret.Complete = true;
            }
            catch (Exception e)
            {
                ret.InternalError = true;
                ret.InternalErrorMessage = e.Message;
            }
            return ret;
        }
    }
}
