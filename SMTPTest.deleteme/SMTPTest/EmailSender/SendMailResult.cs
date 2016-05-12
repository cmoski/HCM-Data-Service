using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMTPTest
{
    public class SendMailResult
    {
        public bool Complete { get; set; }
        public bool InternalError { get; set; }
        public string InternalErrorMessage { get; set; }
    }

}
