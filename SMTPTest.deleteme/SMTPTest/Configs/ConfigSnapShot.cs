using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMTPTest
{
    public class ConfigSnapShot
    {
        public string MailSMTP { get; set; }
        public int MailSMTPPort { get; set; }
        public bool MailSMTPSSL { get; set; }
        public string MailAccountAddress { get; set; }
        public string MailPassword { get; set; }
        public string CCMail { get; set; }
        public string EmailFrom { get; set; }

        public string MailSubject { get; set; }
        public string MailPattern { get; set; }
        public string MailTestAddress { get; set; }

        public void Update()
        {
            MailSMTP = Configuration.MailSMTP;
            MailSMTPPort = Configuration.MailSMTPPort;
            MailSMTPSSL = Configuration.MailSMTPSSL;
            MailAccountAddress = Configuration.MailAccountAddress;
            MailPassword = Configuration.MailPassword;
            CCMail = Configuration.CCMail;
            EmailFrom = Configuration.EmailFrom;

            MailSubject = Configuration.MailSubject;
            MailPattern = Configuration.MailPattern;
            MailTestAddress = Configuration.MailTestAddress;
        }
    }
}
