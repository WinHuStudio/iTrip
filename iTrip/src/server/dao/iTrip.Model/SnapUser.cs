using System;

namespace iTrip.Model
{
    public interface ISnapUser
    {
        /// <summary>
        /// 用户票据
        /// </summary>
        string Ticket { get; set; }
        /// <summary>
        /// 用户账号 
        /// </summary>
        string Account { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        Gender Gender { get; set; }
    }

    /// <summary>
    /// 用户快照
    /// </summary>
    [Serializable]
    public class SnapUser : ISnapUser
    {
        public SnapUser() { }
        public SnapUser(string account, Gender gender, string ticket)
        {
            Account = account;
            Gender = gender;
            Ticket = ticket;
        }

        /// <summary>
        /// 用户票据
        /// </summary>
        public string Ticket { get; set; }
        /// <summary>
        /// 用户账号 
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }
    }
}
