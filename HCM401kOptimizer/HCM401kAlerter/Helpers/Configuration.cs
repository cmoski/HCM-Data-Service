using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCM401kAlerter
{
    public class Configuration
    {

        private static object lockObj = new object();


        static string MailSMTPField;
        static int MailSMTPPortField;
        static bool MailSMTPSSLField;
        static string MailAccountAddressField;
        static string MailPasswordField;
        static string CCMailField;

        static string MailSubjectField;
        static string MailPatternField;
        static string MailTestAddressField;

        static DateTime dtSundayField;
        static DateTime dtSaturdayField;
        static DateTime dtFridayField;
        static DateTime dtThursdayField;
        static DateTime dtWednesdayField;
        static DateTime dtTuesdayField;
        static DateTime dtMondayField;
        static DateTime dtSingleStartTimeField;

        static bool chkSaturdayField;
        static bool chkFridayField;
        static bool chkThursdayField;
        static bool chkWednesdayField;
        static bool chkTuesdayField;
        static bool chkMondayField;
        static bool chkSundayField;
        static bool chkSingleStartTimeField;

        static int RequestBarsCountField;
        static int AroonOscilatorPeriodField;

        static string DataServiceURLField;
        static string DataServiceNameField;
        static string DataServicePasswordField;

        public static string DataServiceURL
        {
            get
            {
                string val = string.Empty;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.DataServiceURL;
                    }
                    catch { }
                }

                DataServiceURLField = val;
                return DataServiceURLField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.DataServiceURL = value;
                        Properties.Settings.Default.Save();
                        DataServiceURLField = value;
                    }
                    catch { }
                }
            }
        }

        public static string DataServiceName
        {
            get
            {
                string val = string.Empty;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.DataServiceName;
                    }
                    catch { }
                }

                DataServiceNameField = val;
                return DataServiceNameField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.DataServiceName = value;
                        Properties.Settings.Default.Save();
                        DataServiceNameField = value;
                    }
                    catch { }
                }
            }
        }

        public static string DataServicePassword
        {
            get
            {
                string val = string.Empty;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.DataServicePassword;
                    }
                    catch { }
                }

                DataServicePasswordField = val;
                return DataServicePasswordField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.DataServicePassword = value;
                        Properties.Settings.Default.Save();
                        DataServicePasswordField = value;
                    }
                    catch { }
                }
            }
        }

        public static int RequestBarsCount
        {
            get
            {
                int val = 0;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.RequestBarsCount;
                    }
                    catch { }
                }

                RequestBarsCountField = val;
                return RequestBarsCountField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.RequestBarsCount = value;
                        Properties.Settings.Default.Save();
                        RequestBarsCountField = value;
                    }
                    catch { }
                }
            }
        }

        public static int AroonOscilatorPeriod
        {
            get
            {
                int val = 0;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.AroonOscilatorPeriod;
                    }
                    catch { }
                }

                AroonOscilatorPeriodField = val;
                return AroonOscilatorPeriodField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.AroonOscilatorPeriod = value;
                        Properties.Settings.Default.Save();
                        AroonOscilatorPeriodField = value;
                    }
                    catch { }
                }
            }
        }

        public static DateTime dtSunday
        {
            get
            {
                DateTime val = DateTime.Now;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.dtSunday;
                    }
                    catch { }
                }

                dtSundayField = val;
                return dtSundayField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.dtSunday = value;
                        Properties.Settings.Default.Save();
                        dtSundayField = value;
                    }
                    catch { }
                }
            }
        }

        public static DateTime dtSaturday
        {
            get
            {
                DateTime val = DateTime.Now;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.dtSaturday;
                    }
                    catch { }
                }

                dtSaturdayField = val;
                return dtSaturdayField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.dtSaturday = value;
                        Properties.Settings.Default.Save();
                        dtSaturdayField = value;
                    }
                    catch { }
                }
            }
        }

        public static DateTime dtFriday
        {
            get
            {
                DateTime val = DateTime.Now;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.dtFriday;
                    }
                    catch { }
                }

                dtFridayField = val;
                return dtFridayField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.dtFriday = value;
                        Properties.Settings.Default.Save();
                        dtFridayField = value;
                    }
                    catch { }
                }
            }
        }

        public static DateTime dtThursday
        {
            get
            {
                DateTime val = DateTime.Now;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.dtThursday;
                    }
                    catch { }
                }

                dtThursdayField = val;
                return dtThursdayField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.dtThursday = value;
                        Properties.Settings.Default.Save();
                        dtThursdayField = value;
                    }
                    catch { }
                }
            }
        }

        public static DateTime dtWednesday
        {
            get
            {
                DateTime val = DateTime.Now;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.dtWednesday;
                    }
                    catch { }
                }

                dtWednesdayField = val;
                return dtWednesdayField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.dtWednesday = value;
                        Properties.Settings.Default.Save();
                        dtWednesdayField = value;
                    }
                    catch { }
                }
            }
        }

        public static DateTime dtTuesday
        {
            get
            {
                DateTime val = DateTime.Now;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.dtTuesday;
                    }
                    catch { }
                }

                dtTuesdayField = val;
                return dtTuesdayField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.dtTuesday = value;
                        Properties.Settings.Default.Save();
                        dtTuesdayField = value;
                    }
                    catch { }
                }
            }
        }

        public static DateTime dtMonday
        {
            get
            {
                DateTime val = DateTime.Now;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.dtMonday;
                    }
                    catch { }
                }

                dtMondayField = val;
                return dtMondayField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.dtMonday = value;
                        Properties.Settings.Default.Save();
                        dtMondayField = value;
                    }
                    catch { }
                }
            }
        }

        public static DateTime dtSingleStartTime
        {
            get
            {
                DateTime val = DateTime.Now;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.dtSingleStartTime;
                    }
                    catch { }
                }

                dtSingleStartTimeField = val;
                return dtSingleStartTimeField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.dtSingleStartTime = value;
                        Properties.Settings.Default.Save();
                        dtSingleStartTimeField = value;
                    }
                    catch { }
                }
            }
        }

        public static bool chkSaturday
        {
            get
            {
                bool val = false;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.chkSaturday;
                    }
                    catch { }
                }

                chkSaturdayField = val;
                return chkSaturdayField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.chkSaturday = value;
                        Properties.Settings.Default.Save();
                        chkSaturdayField = value;
                    }
                    catch { }
                }
            }
        }

        public static bool chkFriday
        {
            get
            {
                bool val = false;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.chkFriday;
                    }
                    catch { }
                }

                chkFridayField = val;
                return chkFridayField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.chkFriday = value;
                        Properties.Settings.Default.Save();
                        chkFridayField = value;
                    }
                    catch { }
                }
            }
        }

        public static bool chkThursday
        {
            get
            {
                bool val = false;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.chkThursday;
                    }
                    catch { }
                }

                chkThursdayField = val;
                return chkThursdayField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.chkThursday = value;
                        Properties.Settings.Default.Save();
                        chkThursdayField = value;
                    }
                    catch { }
                }
            }
        }

        public static bool chkWednesday
        {
            get
            {
                bool val = false;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.chkWednesday;
                    }
                    catch { }
                }

                chkWednesdayField = val;
                return chkWednesdayField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.chkWednesday = value;
                        Properties.Settings.Default.Save();
                        chkWednesdayField = value;
                    }
                    catch { }
                }
            }
        }

        public static bool chkTuesday
        {
            get
            {
                bool val = false;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.chkTuesday;
                    }
                    catch { }
                }

                chkTuesdayField = val;
                return chkTuesdayField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.chkTuesday = value;
                        Properties.Settings.Default.Save();
                        chkTuesdayField = value;
                    }
                    catch { }
                }
            }
        }

        public static bool chkMonday
        {
            get
            {
                bool val = false;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.chkMonday;
                    }
                    catch { }
                }

                chkMondayField = val;
                return chkMondayField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.chkMonday = value;
                        Properties.Settings.Default.Save();
                        chkMondayField = value;
                    }
                    catch { }
                }
            }
        }

        public static bool chkSunday
        {
            get
            {
                bool val = false;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.chkSunday;
                    }
                    catch { }
                }

                chkSundayField = val;
                return chkSundayField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.chkSunday = value;
                        Properties.Settings.Default.Save();
                        chkSundayField = value;
                    }
                    catch { }
                }
            }
        }

        public static bool chkSingleStartTime
        {
            get
            {
                bool val = false;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.chkSingleStartTime;
                    }
                    catch { }
                }

                chkSingleStartTimeField = val;
                return chkSingleStartTimeField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.chkSingleStartTime = value;
                        Properties.Settings.Default.Save();
                        chkSingleStartTimeField = value;
                    }
                    catch { }
                }
            }
        }

        public static string MailSMTP
        {
            get
            {
                string val = string.Empty;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.MailSMTP;
                    }
                    catch { }
                }

                MailSMTPField = val;
                return MailSMTPField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.MailSMTP = value;
                        Properties.Settings.Default.Save();
                        MailSMTPField = value;
                    }
                    catch { }
                }
            }
        }

        public static int MailSMTPPort
        {
            get
            {
                int val = 25;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.MailSMTPPort;
                    }
                    catch { }
                }

                MailSMTPPortField = val;
                return MailSMTPPortField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.MailSMTPPort = value;
                        Properties.Settings.Default.Save();
                        MailSMTPPortField = value;
                    }
                    catch { }
                }
            }
        }

        public static bool MailSMTPSSL
        {
            get
            {
                bool val = false;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.MailSMTPSSL;
                    }
                    catch { }
                }

                MailSMTPSSLField = val;
                return MailSMTPSSLField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.MailSMTPSSL = value;
                        Properties.Settings.Default.Save();
                        MailSMTPSSLField = value;
                    }
                    catch { }
                }
            }
        }

        public static string MailAccountAddress
        {
            get
            {
                string val = string.Empty;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.MailAccountAddress;
                    }
                    catch { }
                }

                MailAccountAddressField = val;
                return MailAccountAddressField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.MailAccountAddress = value;
                        Properties.Settings.Default.Save();
                        MailAccountAddressField = value;
                    }
                    catch { }
                }
            }
        }

        public static string MailPassword
        {
            get
            {
                string val = string.Empty;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.MailPassword;
                    }
                    catch { }
                }

                MailPasswordField = val;
                return MailPasswordField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.MailPassword = value;
                        Properties.Settings.Default.Save();
                        MailPasswordField = value;
                    }
                    catch { }
                }
            }
        }

        public static string CCMail
        {
            get
            {
                string val = string.Empty;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.CCMail;
                    }
                    catch { }
                }

                CCMailField = val;
                return CCMailField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.CCMail = value;
                        Properties.Settings.Default.Save();
                        CCMailField = value;
                    }
                    catch { }
                }
            }
        }

        public static string MailSubject
        {
            get
            {
                string val = string.Empty;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.MailSubject;
                    }
                    catch { }
                }

                MailSubjectField = val;
                return MailSubjectField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.MailSubject = value;
                        Properties.Settings.Default.Save();
                        MailSubjectField = value;
                    }
                    catch { }
                }
            }
        }

        public static string MailPattern
        {
            get
            {
                string val = string.Empty;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.MailPattern;
                    }
                    catch { }
                }

                MailPatternField = val;
                return MailPatternField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.MailPattern = value;
                        Properties.Settings.Default.Save();
                        MailPatternField = value;
                    }
                    catch { }
                }
            }
        }

        public static string MailTestAddress
        {
            get
            {
                string val = string.Empty;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.MailTestAddress;
                    }
                    catch { }
                }

                MailTestAddressField = val;
                return MailTestAddressField;
            }
            set
            {

                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.MailTestAddress = value;
                        Properties.Settings.Default.Save();
                        MailTestAddressField = value;
                    }
                    catch { }
                }
            }
        }

    }
}
