using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace HCM401kAlerter
{
    [ServiceContract]
    interface IService
    {
        [OperationContract]
        WCFBarData GetXHistorcalData(string code, string id, string symbol, int max);
    }
}
