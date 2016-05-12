using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Net;

namespace HCM401kAlerter
{
    internal class Yahoo : IDataFeed
    {
        #region members

        string easternZoneId = "Eastern Standard Time";
        TimeZoneInfo easternZone;

        #endregion

        public Yahoo()
        {

        }

        #region History Data

        public void GetHistory(HistoryRequest value)
        {
            easternZone = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId);

            BarInfo token = new BarInfo
            {
                Token = value
            };
            WebClient webSvc = new WebClient();
            webSvc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webSvc_DownloadStringCompleted);
            Uri addressValue = GetHistiryRequestUri(value);
            webSvc.DownloadStringAsync(addressValue, token);
        }

        public event HistoryReadyHandler HistoryReady;
        private void OnHistoryReady(BarInfo value)
        {
            if (HistoryReady != null)
            {
                HistoryReady(this, value);
            }
        }

        private void webSvc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            BarInfo bars = (BarInfo)e.UserState;
            ((WebClient)sender).DownloadStringCompleted -= webSvc_DownloadStringCompleted;
            if (e.Error == null)
                if (e.Result != null)
                {
                    string requestStr = e.Result;
                    List<string> responseRows = new List<string>();
                    responseRows.AddRange(requestStr.Split('\n'));

                    int outnum = 0;
                    if (responseRows.Count - 2 > bars.Token.MaxAmount)
                        outnum = responseRows.Count - bars.Token.MaxAmount - 1;

                    for (int i = 1; i < responseRows.Count - outnum; i++)
                    {
                        string[] rowElements = responseRows[i].Split(',');

                        if (rowElements.Length >= 7)
                        {
                            System.DateTime tStamp = ParseDate(rowElements[0]);
                            double open = double.Parse(rowElements[1]);
                            double high = double.Parse(rowElements[2]);
                            double low = double.Parse(rowElements[3]);
                            double close = double.Parse(rowElements[4]);
                            double volume = double.Parse(rowElements[5]);
                            //double adjustedClose = double.Parse(rowElements[6]);

                            bars.Add(new Bar
                            {
                                Close = close,
                                High = high,
                                Low = low,
                                Open = open,
                                TimeStamp = tStamp,
                                Volume = volume
                            });
                        }
                    }

                    OnHistoryReady(bars);
                }
        }

        private Uri GetHistiryRequestUri(HistoryRequest value)
        {
            string symbol = value.Symbol;

            if (symbol.Length == 7 && symbol[3] == '/')
            {
                symbol = symbol.Remove(3, 1);
                symbol += "=X";//Forex symbol
            }

            string address = "http://ichart.finance.yahoo.com/table.csv";
            address += "?s=" + symbol;
            System.DateTime beginDate = GetBeginDate(value.periodicity, value.period, value.MaxAmount);
            address += "&a=" + (beginDate.Month - 1).ToString();
            // current month (yahoo range is 0-11, basic range is 1-12, so here is '- 1')
            address += "&b=" + beginDate.Day;
            address += "&c=" + beginDate.Year;
            address += "&d=" + (DateTime.Now.Month - 1);
            address += "&e=" + DateTime.Now.Day;
            address += "&f=" + DateTime.Now.Year;

            switch (value.periodicity)
            {
                case Periodicity.Day:
                    address += "&g=" + "d";
                    break;
                case Periodicity.Week:
                    address += "&g=" + "w";
                    break;
                case Periodicity.Month:
                    address += "&g=" + "m";
                    break;
            }

            address += "&ignore=" + ".csv";
            Uri uri = new Uri(address);
            return new Uri(address);
        }

        private System.DateTime GetBeginDate(Periodicity barType, int period, int bars)
        {
            System.DateTime neededDate = System.DateTime.Now;
            if ((barType == Periodicity.Month))
                neededDate = neededDate.AddMonths(-bars * period);
            else if ((barType == Periodicity.Week))
            {
                int days = bars * 7;
                neededDate = neededDate.AddDays(-days * period);
            }
            else
            {
                neededDate = neededDate.AddDays((-bars - bars * 0.6) * period);
            }
            return neededDate;
        }

        private System.DateTime ParseDate(string dateStr)
        {
            System.DateTime retDate = DateTime.Now;
            string format = "yyyy-MM-dd";
            System.DateTime.TryParseExact(dateStr, format, null, DateTimeStyles.None, out retDate);
            retDate = new DateTime(retDate.Year, retDate.Month, retDate.Day, 16, 0, 0);

            return TimeZoneInfo.ConvertTimeToUtc(retDate, easternZone);
        }

        #endregion //History Data
    }
}
