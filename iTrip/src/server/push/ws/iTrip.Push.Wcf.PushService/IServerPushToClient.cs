using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.Proxy;

namespace iTrip.Push.Wcf.PushService
{
    [ServiceContract]
    public interface IServerPushToClient
    {
        [OperationContract(IsOneWay = true)]
        void PushPackage(ipp_Package[] package, string receiver);
    }
}
