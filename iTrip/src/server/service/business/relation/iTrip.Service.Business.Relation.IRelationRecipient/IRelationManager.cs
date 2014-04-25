using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.RelationCenter;

namespace iTrip.Service.Business.Relation.IRelationRecipient
{
    public interface IRelationManager
    {
        /// <summary>
        /// 邀请好友
        /// </summary>
        /// <param name="applicant">邀请人账号</param>
        /// <param name="applicantname">邀请人姓名</param>
        /// <param name="destacc">受邀人账号</param>
        /// <param name="memo">邀请说明</param>
        /// <returns></returns>
        StandardResult ApplyFriend(string applicant, string applicantname, string destacc, string memo);

        /// <summary>
        /// 接受好友申请
        /// </summary>
        /// <param name="person">接受人账号</param>
        /// <param name="applicationId">申请单号</param>
        /// <returns>返回操作结果</returns>
        bool AcceptApplication(string person, string applicationId);

        /// <summary>
        /// 获取用户好友列表
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <returns>返回好友账号列表</returns>
        Member[] GetMyFriends(string account);


    }
}
