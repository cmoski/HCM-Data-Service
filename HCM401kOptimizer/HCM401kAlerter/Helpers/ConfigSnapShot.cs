using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCM401kAlerter
{
    public class ConfigSnapShot
    {
        public string MailSMTP { get; set; }
        public int MailSMTPPort { get; set; }
        public bool MailSMTPSSL { get; set; }
        public string MailAccountAddress { get; set; }
        public string MailPassword { get; set; }
        public string CCMail { get; set; }

        public string MailSubject { get; set; }
        public string MailPattern { get; set; }
        public string MailTestAddress { get; set; }

        public DateTime dtSunday { get; set; }
        public DateTime dtSaturday { get; set; }
        public DateTime dtFriday { get; set; }
        public DateTime dtThursday { get; set; }
        public DateTime dtWednesday { get; set; }
        public DateTime dtTuesday { get; set; }
        public DateTime dtMonday { get; set; }
        public DateTime dtSingleStartTime { get; set; }

        public bool chkSaturday { get; set; }
        public bool chkFriday { get; set; }
        public bool chkThursday { get; set; }
        public bool chkWednesday { get; set; }
        public bool chkTuesday { get; set; }
        public bool chkMonday { get; set; }
        public bool chkSunday { get; set; }
        public bool chkSingleStartTime { get; set; }

        public int RequestBarsCount { get; set; }
        public int AroonOscilatorPeriod { get; set; }

        public string DataServiceURL { get; set; }
        public string DataServiceName { get; set; }
        public string DataServicePassword { get; set; }

        public void Update()
        {
            MailSMTP = Configuration.MailSMTP;
            MailSMTPPort = Configuration.MailSMTPPort;
            MailSMTPSSL = Configuration.MailSMTPSSL;
            MailAccountAddress = Configuration.MailAccountAddress;
            MailPassword = Configuration.MailPassword;
            CCMail = Configuration.CCMail;

            MailSubject = Configuration.MailSubject;
            MailPattern = Configuration.MailPattern;
            MailTestAddress = Configuration.MailTestAddress;

            dtSunday = Configuration.dtSunday;
            dtSaturday = Configuration.dtSaturday;
            dtFriday = Configuration.dtFriday;
            dtThursday = Configuration.dtThursday;
            dtWednesday = Configuration.dtWednesday;
            dtTuesday = Configuration.dtTuesday;
            dtMonday = Configuration.dtMonday;
            dtSingleStartTime = Configuration.dtSingleStartTime;

            chkSaturday = Configuration.chkSaturday;
            chkFriday = Configuration.chkFriday;
            chkThursday = Configuration.chkThursday;
            chkWednesday = Configuration.chkWednesday;
            chkTuesday = Configuration.chkTuesday;
            chkMonday = Configuration.chkMonday;
            chkSunday = Configuration.chkSunday;
            chkSingleStartTime = Configuration.chkSingleStartTime;

            RequestBarsCount = Configuration.RequestBarsCount;
            AroonOscilatorPeriod = Configuration.AroonOscilatorPeriod;

            DataServiceURL = Configuration.DataServiceURL;
            DataServiceName = Configuration.DataServiceName;
            DataServicePassword = Configuration.DataServicePassword;

        }
    }
}
