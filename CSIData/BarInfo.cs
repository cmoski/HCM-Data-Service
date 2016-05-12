using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSIData
{
    public class BarInfo : List<Bar>
    {
        public HistoryRequest Token { get; set; }
    }
}
