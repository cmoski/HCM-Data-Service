using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;

namespace HCM401kAlerter
{
    [ServiceContract]
    interface IServiceREST
    {
        [OperationContract]
        [WebGet(UriTemplate = "/clientaccesspolicy.xml")]
        Stream GetClientPolicy();

        [OperationContract]
        [WebGet(UriTemplate = "/GetHistoricalData?code={code}&id={id}&symbol={symbol}&max={max}")]
        Stream GetHistoricalData(string code, string id, string symbol, int max);
    }
}
