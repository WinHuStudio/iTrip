using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Model;

namespace iTrip.TripperCenter
{
    /// <summary>
    /// 用户资料
    /// </summary>
    public class Profile : UEntity
    {
        public Profile()
        {
            Gender = Gender.Unknown;
            LastTime = DateTime.Now;
        }
        /// <summary>
        /// 用户首次登录构造函数（Name=Account）
        /// </summary>
        /// <param name="account">账户名</param>
        /// <param name="client">客户端类型</param>
        /// <param name="clientsn">客户端标识</param>
        public Profile(string account)
        {
            Account = account;
            Name = account;
            Gender = Gender.Unknown;
            LastTime = DateTime.Now;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 个性签名
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Telphone { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LastTime { get; set; }
        /// <summary>
        /// 用户头像（相对路径）
        /// </summary>
        public string Photo { get; set; }
    }
}
