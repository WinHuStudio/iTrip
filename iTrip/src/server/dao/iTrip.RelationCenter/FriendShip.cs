using iTrip.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.RelationCenter
{
    /// <summary>
    /// 好友关系
    /// </summary>
    public class FriendShip : REntity
    {
        public FriendShip()
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inviter">邀请人</param>
        /// <param name="invitee">被邀请人</param>
        /// <param name="message">邀请留言</param>
        public FriendShip(string inviter, string invitee, string message)
        {
            this.Inviter = inviter;
            this.Invitee = invitee;
            this.Message = message;
            InvitationDate = DateTime.Now;
        }
        /// <summary>
        /// 邀请者
        /// </summary>
        public string Inviter { get; set; }
        /// <summary>
        /// 被邀请者
        /// </summary>
        public string Invitee { get; set; }
        /// <summary>
        /// 邀请时间
        /// </summary>
        public DateTime InvitationDate { get; set; }
        /// <summary>
        /// 邀请留言
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 答复时间
        /// </summary>
        public DateTime AnswerDate { get; set; }
        private FriendShipStatus _status = FriendShipStatus.Invited;
        /// <summary>
        /// 好友关系状态
        /// </summary>
        public FriendShipStatus Status { get { return _status; } set { _status = value; } }
    }
}
