using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Globalization;

namespace HCM401kAlerter
{
    internal static class LogFile
    {
        internal static string LogFileName = "Output.txt";
        private static object lockObject = new object();
        private static string TextCache = string.Empty;
        internal static void WriteToLog(string message)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(WriteAsync), message);
        }

        private static void WriteAsync(object message)
        {
            lock (lockObject)
            {
                string text = DateTime.Now.ToString(CultureInfo.InvariantCulture) + "\t=>\t" + (message as string);
                try
                {
                    using (StreamWriter log = new StreamWriter(LogFileName, true))
                    {
                        string wtext = string.Empty;
                        if (!string.IsNullOrEmpty(TextCache))
                            wtext = TextCache + "\r\n" + text;
                        else
                            wtext = text;
                        log.WriteLine(text);
                        log.Flush();
                    }
                    TextCache = string.Empty;
                }
                catch
                {
                    if (!string.IsNullOrEmpty(TextCache))
                        TextCache = TextCache + "\r\n" + text;
                    else
                        TextCache = text;
                }
            }
        }
    }

}
