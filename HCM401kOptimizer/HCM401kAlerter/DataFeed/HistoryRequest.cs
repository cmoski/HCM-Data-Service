using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCM401kAlerter
{
    public class HistoryRequest
    {
        public string Symbol { get; set; }
        public Periodicity periodicity { get; set; }
        public int period { get; set; }
        public string ID { get; set; }
        public int MaxAmount { get; set; }

        public bool isEqual(HistoryRequest value)
        {
            bool ret = true;
            if (this.ID != value.ID
               || this.MaxAmount != value.MaxAmount
               || this.period != value.period
               || this.periodicity != value.periodicity
               || this.Symbol != value.Symbol)
                ret = false;
            return ret;
        }
    }
}
