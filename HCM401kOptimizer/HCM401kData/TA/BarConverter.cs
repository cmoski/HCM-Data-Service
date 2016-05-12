using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace HCM401kData.TA
{
    public class BarConverter
    {
        public static List<WCFBar> ConvertToWeekly(List<WCFBar> data)
        {
            DateTime dt = DateTime.MinValue;
            DateTime lastDate = DateTime.MinValue;
            List<WCFBar> ret = new List<WCFBar>(); 
            var srtData = data.OrderBy(x => x.TimeStamp);
            foreach (var itm in srtData)
            {
                if (dt.Date < itm.TimeStamp.Date)
                {
                    dt = CloseWeekDate(itm.TimeStamp);
                    ret.Add(new WCFBar
                    {
                        Close = itm.Close,
                        High = itm.High,
                        Low = itm.Low,
                        Open = itm.Open,
                        TimeStamp = dt,
                        Volume = itm.Volume
                    });
                }
                else
                {
                    var bar = ret[ret.Count - 1];
                    bar.Close = itm.Close;
                    bar.High = bar.High > itm.High ? bar.High : itm.High;
                    bar.Low = bar.Low < itm.High ? bar.Low : itm.Low;
                    bar.Volume += itm.Volume;
                }
                lastDate = itm.TimeStamp;
            }
            if (ret.Count > 0)
                ret[ret.Count - 1].TimeStamp = lastDate;
            return ret;
        }

        private static DateTime CloseWeekDate(DateTime current)
        {
            DateTime ret = current;
            while (ret.DayOfWeek != DayOfWeek.Friday)
                ret = ret.AddDays(1);
            return ret;
        }
    }
}
