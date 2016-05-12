using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCM401kAlerter
{
    public delegate void HistoryReadyHandler(object sender, BarInfo value);

    interface IDataFeed
    {
        #region History Data

        void GetHistory(HistoryRequest value);

        #endregion //History Data

    }

}
