using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Service.Wcf.Relation.ITripperRelationShipResolver
{
    [ServiceContract]
    public interface IRecipientRegistration
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="ticket">票据</param>
        [OperationContract(IsOneWay = true)]
        void RegisterTripper(string account, string ticket);

        /// <summary>
        /// 注册群组（返回群组账号）
        /// </summary>
        /// <param name="master">群组账号</param>
        /// <param name="name">群组名称</param>
        /// <returns>返回群组账号</returns>
        [OperationContract]
        string RegisterGroup(string master, string name);

        /// <summary>
        /// 注册公共账号（返回公共账号）
        /// </summary>
        /// <param name="master">公共账号</param>
        /// <param name="name">公共账号名称</param>
        /// <returns>返回公共账号</returns>
        [OperationContract]
        string RegisterOrganization(string master, string name);

        /// <summary>
        /// 注册团体账号（返回团体账号）
        /// </summary>
        /// <param name="master">团体账号</param>
        /// <param name="name">团体账号名称</param>
        /// <returns>返回团体账号</returns>
        [OperationContract]
        string RegisterCommunity(string master, string name);


    }
}
