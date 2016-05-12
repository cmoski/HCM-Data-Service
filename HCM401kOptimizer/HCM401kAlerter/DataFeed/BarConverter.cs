using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCM401kAlerter.DataFeed
{
   public class BarConverter
    {

        public static BarInfo ConvertToWeekly(BarInfo data)
        {
            DateTime dt = DateTime.MinValue;
            DateTime lastDate = DateTime.MinValue;
            data.Token.periodicity = Periodicity.Week;
            BarInfo ret = new BarInfo { Token = data.Token };
            var srtData = data.OrderBy(x => x.TimeStamp);
            foreach (var itm in srtData)
            {
                if (dt.Date < itm.TimeStamp.Date)
                {
                    dt = CloseWeekDate(itm.TimeStamp);
                    ret.Add(new Bar
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
