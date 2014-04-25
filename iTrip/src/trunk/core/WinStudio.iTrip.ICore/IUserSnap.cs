using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.iTrip.Models;

namespace WinStudio.iTrip.ICore
{
    public interface IUserSnap
    {
        /// <summary>
        /// 用户安全识别码
        /// </summary>
        string SecurityKey { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        string Id { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        string Account { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        DateTime LoginTime { get; set; }
        /// <summary>
        /// 登录代码
        /// </summary>
        string LoginCode { get; set; }
        /// <summary>
        /// 登录类型
        /// </summary>
        LoginType LoginType { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        string Email { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        DateTime RegisteredTime { get; set; }


    }
}
