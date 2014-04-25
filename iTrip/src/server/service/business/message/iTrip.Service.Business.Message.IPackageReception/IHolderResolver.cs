using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.DeliveryCenter;
using iTrip.iPP.IProxy;
using MongoDB.Driver;

namespace iTrip.Service.Business.Message.IPackageReception
{
    public interface IHolderResolver
    {
        /// <summary>
        /// 为持有者附加包裹（如果持有者账号不存在，则新建）
        /// </summary>
        /// <param name="holders">持有者</param>
        /// <param name="package">消息包裹</param>
        /// <returns></returns>
        int AttachPackage(string[] holders, MongoDBRef package);

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="ticket">票据</param>
        void RegisterTripper(string account, string ticket);
    }
}
