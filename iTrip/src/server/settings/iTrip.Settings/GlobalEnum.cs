using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip
{

    public enum DeviceType
    {
        Unknown = 0,
        Android = 1,
        iOS = 2,
        WinPhone = 3
    }
    public enum Gender
    {
        Female = 0,
        Male = 1,
        Unknown = 100
    }

    public enum OOStatus
    {
        Offline = 0,
        Online = 1,
        Background = 2,
        Hidden = 3
    }
    /// <summary>
    ///好友关系状态
    /// </summary>
    public enum FriendShipStatus
    {
        /// <summary>
        /// 已邀请
        /// </summary>
        Invited = 0,
        /// <summary>
        /// 已同意
        /// </summary>
        Agreed = 1,
        /// <summary>
        /// 拒绝
        /// </summary>
        Rejective = 2,
        /////解除关系后，直接删除关系记录，不保存解除后关系
        ///// <summary>
        ///// 邀请人解除关系
        ///// </summary>
        //InviterUnfriend = 3,
        ///// <summary>
        ///// 被邀请人解除关系
        ///// </summary>
        //InviteeUnfriend = 4,
    }
}
