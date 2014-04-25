using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.Proxy;

namespace iTrip.Service.Wcf.Message.IPublisherIM
{
    [ServiceContract]
    public interface IPackageDelivery
    {
        [OperationContract(IsOneWay = true)]
        void RegisterTripper(string account, string ticket);

        /// <summary>
        /// 投递包裹（发送）
        /// </summary>
        /// <param name="package">包裹</param>
        /// <returns></returns>
        [OperationContract(IsOneWay = true)]
        void PackageDeliveryToServer(ipp_Package package);

        /// <summary>
        /// 投递包裹（接收）
        /// </summary>
        /// <param name="account">接收人</param>
        /// <param name="lastTime">上次接收时间</param>
        /// <returns></returns>
        [OperationContract]
        StandardResult PackageDeliveryToClient(string account, DateTime lastTime);
    }
}
