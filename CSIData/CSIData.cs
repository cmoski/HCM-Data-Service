using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UA;

namespace CSIData
{
    public class CSIData
    {
        private API2Class uaApi2;
        private TimeZoneInfo ETCZone;

        public delegate void GetHistoryDelegate(HistoryRequest value);
        public void GetHistoryAsync(HistoryRequest value)
        {
            GetHistoryDelegate dlg = new GetHistoryDelegate(InnerGetHistory);
            dlg.BeginInvoke(value, new AsyncCallback(DeleteStockScannerDone), dlg);
        }
        public delegate void GetHistoryCompleteHandler(object sender, BarInfo value);
        public event GetHistoryCompleteHandler GetHistoryComplete;
        private void OnGetHistoryComplete(BarInfo value)
        {
            if (GetHistoryComplete != null)
                GetHistoryComplete(this, value);
        }
        private void DeleteStockScannerDone(IAsyncResult result)
        {
            ((GetHistoryDelegate)result.AsyncState).EndInvoke(result);
        }

        private void InnerGetHistory(HistoryRequest value)
        {
            var data = GetHistory(value);
            OnGetHistoryComplete(data);
        }

        public BarInfo GetHistory(HistoryRequest value)
        {
            BarInfo ret = new BarInfo { Token = value };
            object IntResultArray = null;
            object FltResultArray = null;
            try
            {
            if (uaApi2 == null)
                uaApi2 = new API2Class();
            
                uaApi2.MarketSymbol = value.Symbol;
                uaApi2.IsStock = 1;
                int MarketNumber = uaApi2.FindMarketNumber();
                int Count = 0;
                if (MarketNumber == -1)
                {
                    uaApi2.IsStock = 0;
                    MarketNumber = uaApi2.FindMarketNumber();
                }
                if (MarketNumber != -1)
                {
                    // JSM added 20130715
                    uaApi2.ApplyStockSplitAdjustments = 1;
                    uaApi2.ApplyStockDividendAdjustments = 1;
                    uaApi2.PropStockAdjustments = 1;
                    uaApi2.PropStockVolumeAdjustments = 1;
                    uaApi2.RoundToTick = 1;

                    uaApi2.RetrieveStock(MarketNumber, int.Parse(GetBeginDate(value.period, value.MaxAmount).ToString("yyyyMMdd")), int.Parse(DateTime.Now.ToString("yyyyMMdd")));
                    Count = uaApi2.CopyRetrievedDataToArray2(0, out IntResultArray, out FltResultArray);
                    double[,] singleArray = FltResultArray as double[,];
                    Int32[,] intArray = IntResultArray as Int32[,];
                    for (int j = 0; j < Count; j++)
                        ret.Add(new Bar() { TimeStamp = ParseDate(intArray[0, j].ToString()), Open = singleArray[1, j], High = singleArray[2, j], Low = singleArray[3, j], Close = singleArray[4, j], Volume = intArray[3, j] });
                }
            }
            catch (Exception e)
            {
                uaApi2 = null;
                value.Message = e.Message;
                throw e;
            }
            return ret;
        }

        private DateTime GetBeginDate(int period, int bars)
        {
            DateTime neededDate = DateTime.Now;
            neededDate = neededDate.AddDays((-bars - bars * 0.6) * period);
            return neededDate;
        }

        private DateTime ParseDate(string dateStr)
        {
            DateTime retDate = DateTime.ParseExact(dateStr, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            retDate = new DateTime(retDate.Year, retDate.Month, retDate.Day, 16, 0, 0);
            if(ETCZone == null)
                ETCZone =TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return TimeZoneInfo.ConvertTimeToUtc(retDate, ETCZone);
        }

    }
}
