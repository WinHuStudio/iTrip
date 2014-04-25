using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Service.Wcf.Relation.ITripperRelationShipResolver
{
    [ServiceContract]
    public interface IRecipientShipManager
    {
        /// <summary>
        /// 申请好友（返回申请单号）
        /// </summary>
        /// <param name="applicant">申请人账号</param>
        /// <param name="friend">好友账号</param>
        /// <param name="memo">申请信息</param>
        /// <returns>返回申请单号</returns>
        [OperationContract]
        StandardResult ApplyFriend(string applicant, string friend, string memo);

        /// <summary>
        /// 接受好友申请
        /// </summary>
        /// <param name="accepter">接受人账号</param>
        /// <param name="applicationId">申请单号</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        StandardResult AcceptApplication(string accepter, string applicationId);

        /// <summary>
        /// 获取用户好友列表
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <returns>返回用户好友列表</returns>
        StandardResult GetFriends(string account);
    }
}
