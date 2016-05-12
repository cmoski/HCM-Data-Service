using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMTPTest
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
        static string EmailFromField;

        static string MailSubjectField;
        static string MailPatternField;
        static string MailTestAddressField;

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

        public static string EmailFrom
        {
            get
            {
                string val = string.Empty;
                lock (lockObj)
                {
                    try
                    {
                        val = Properties.Settings.Default.EmailFrom;
                    }
                    catch { }
                }

                EmailFromField = val;
                return EmailFromField;
            }
            set
            {
                lock (lockObj)
                {
                    try
                    {
                        Properties.Settings.Default.EmailFrom = value;
                        Properties.Settings.Default.Save();
                        EmailFromField = value;
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
