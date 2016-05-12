using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    class Program
    {
        static string dAccessCode = "E5136ED93A4B4687AD12089A5416D21A";

        static string dSymbol = "GOOG";
        static string dCount = "10";
        static string dIP = "localhost:4528";

        static void Main(string[] args)
        {
            NewRequest();
        }

        static void NewRequest()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=======GET CSI DATA TEST APPLICATION=========\r\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(string.Format("enter symbol (default: '{0}'):", dSymbol));
            string symb = Console.ReadLine();
            if (string.IsNullOrEmpty(symb.Trim()))
                symb = dSymbol;
            else
                dSymbol = symb.Trim().ToUpper();
            Console.WriteLine(string.Format("\r\nenter aprox. count (default: '{0}'):", dCount));
            string scnt = Console.ReadLine();
            if (string.IsNullOrEmpty(scnt.Trim()))
                scnt = dCount;
            else
                dCount = scnt.Trim();
            Console.WriteLine(string.Format("\r\nenter address (defaul: '{0}'):", dIP));
            string ip = Console.ReadLine();
            if (string.IsNullOrEmpty(ip.Trim()))
                ip = dIP;
            else
                dIP = ip.Trim();

            int cnt = 1;
            int.TryParse(scnt.Trim(), out cnt);
            try
            {
                var cln = new System.Net.WebClient();
                string str = string.Empty;
                str = cln.DownloadString(string.Format("http://{0}/GetHistoricalData?code={1}&symbol={2}&id={3}&max={4}", ip.Trim(), dAccessCode, symb, "id-id", cnt));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(str);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("------------------THE END-------------\r\npress 'R' for new request or any key to exit...");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.R)
                NewRequest();
        }
    }
}
