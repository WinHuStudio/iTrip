using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.iTrip.ICore;
using WinStudio.iTrip.Models;

namespace WinStudio.iTrip.Core
{
    [Serializable]
    public class UserSnap : IUserSnap
    {
        public UserSnap()
        {
            LoginTime = DateTime.Now;
        }

        /// <summary>
        /// 用户安全识别码
        /// </summary>
        public string SecurityKey { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }

        public DateTime LoginTime { get; set; }

        public string LoginCode { get; set; }

        public LoginType LoginType { get; set; }

        public string Email { get; set; }

        public DateTime RegisteredTime { get; set; }
    }
}
