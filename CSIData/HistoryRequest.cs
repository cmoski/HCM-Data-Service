using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSIData
{
    public class HistoryRequest
    {
        public string Symbol { get; set; }
        public int period { get; set; }
        public string ID { get; set; }
        public int MaxAmount { get; set; }
        public string Message{get; internal set;}

        public bool isEqual(HistoryRequest value)
        {
            bool ret = true;
            if (this.ID != value.ID
               || this.MaxAmount != value.MaxAmount
               || this.period != value.period
               || this.Symbol != value.Symbol)
                ret = false;
            return ret;
        }
    }
}
