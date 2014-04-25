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
    public interface IPackageDealer
    {
        /// <summary>
        /// 保存包裹
        /// </summary>
        /// <param name="package">包裹</param>
        /// <returns></returns>
        MongoDBRef SavePackage(IPackage package);

        /// <summary>
        /// 处理包裹（如果持有者不存在，则新建；返回已处理的数量）
        /// </summary>
        /// <param name="MongoDBRef">包裹</param>
        /// <param name="holders">持有者</param>
        /// <returns></returns>
        int DealPackage(MongoDBRef package, string[] holders);

        /// <summary>
        /// 挑拣持有者的包裹
        /// </summary>
        /// <param name="receiver">包裹持有者</param>
        /// <param name="LastPickTime">上次挑拣时间</param>
        /// <returns></returns>
        List<IPackage> PickPackage(string holder, DateTime LastPickTime);
    }
}
