using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using HCM401kAlerter.Properties;
using System.ServiceModel.Web;
using System.Windows.Forms;

namespace HCM401kAlerter
{
    public class WCFService : IServiceREST, IService
    {
        #region members

        private static ServiceHost ServiceHostServer;

        #endregion //members

        #region service methods

        public Stream GetClientPolicy()
        {
            byte[] buffer = null;
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Position = 0;
                using (StreamWriter sw = new StreamWriter(ms))
                {
                    sw.WriteLine(Resources.crossdomainpolicy);
                }
                buffer = ms.GetBuffer();
            }
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
            return new MemoryStream(buffer);
        }


        public Stream GetHistoricalData(string code, string id, string symbol, int max)
        {
            var data = GetData(code, id, symbol, max);
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(data.XmlSerialize<WCFBarData>());
            return new MemoryStream(bytes);
        }

        public WCFBarData GetXHistorcalData(string code, string id, string symbol, int max)
        {
            return GetData(code, id, symbol, max);
        }


        private WCFBarData GetData(string code, string id, string symbol, int max)
        {
            WCFBarData data = new WCFBarData { ID = id, Symbol = symbol, Data = new List<WCFBar>() };
            if (code == "E5136ED93A4B4687AD12089A5416D21A")//Simple validation - hardcoded password
            {
                try
                {
                    var hyst = frmMain.CSIFeed.GetHistory(new CSIData.HistoryRequest { ID = id, MaxAmount = max, period = 1, Symbol = symbol });
                    foreach (var itm in hyst)
                        data.Data.Add(new WCFBar
                        {
                            Close = itm.Close,
                            High = itm.High,
                            Low = itm.Low,
                            Open = itm.Open,
                            TimeStamp = itm.TimeStamp,
                            Volume = itm.Volume
                        });
                }
                catch(Exception e)
                {
                    LogFile.WriteToLog(string.Format("Message: {0}, \n StackTrace: {1}", e.Message, e.StackTrace));
                }
            }
            return data;
        }

        #endregion //service methods

        #region START/STOP service

        public static bool Start()
        {
            bool ret = false;
            if (ServiceHostServer == null)
            {
                try
                {
                    ServiceHostServer = new ServiceHost(typeof(WCFService));
                    ServiceHostServer.Open();
                    ret = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Start service failed - " + e.Message + ". You need to run as administrator (you should only need to do \"netsh http add urlacl url=http://+:8731/ user=IP-0A501D24\\john\")");
                }
            }
            return ret;
        }

        public static bool Stop()
        {
            bool ret = false;
            if (ServiceHostServer != null)
                try
                {
                    ServiceHostServer.Close();
                    ServiceHostServer = null;
                    ret = true;
                }
                catch { }
            return ret;
        }

        #endregion //START/STOP service
    }
}
