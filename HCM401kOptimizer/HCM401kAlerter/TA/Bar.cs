using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCM401kAlerter
{
    public class Bar
    {
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class BarInfo : List<Bar>
    {
      public  HistoryRequest Token { get; set; }
    }
}
