using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Model;
using WinStudio.ComResult;

namespace iTrip.Business.Authentication
{
    public interface IServiceAuthentication
    {
        /// <summary>
        /// 用户注册（无登录功能）
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码（MD5加密）</param>
        /// <returns>true/false</returns>
        ComRet Register(string account, string password);

        /// <summary>
        /// 用户登出（服务端只改变用户状态为offline，客户端需要移除当前有效票据）
        /// </summary>
        /// <param name="ticket">票据</param>
        /// <returns>true/false</returns>
        ComRet Logout(string ticket);

        /// <summary>
        /// 用户登录（改变用户状态为online，并返回用户票据）
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码（MD5加密）</param>
        /// <param name="client">登录客户端类型</param>
        /// <param name="client_sn">登录客户端标识</param>
        /// <returns>Json{ret=true/false,msg=ticket}</returns>
        ComRet Login(string account, string password, ClientType client, string client_sn);

        /// <summary>
        /// 检查用户票据
        /// </summary>
        /// <param name="ticket">票据</param>
        /// <returns>true/false</returns>
        ComRet CheckTicket(string ticket);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="ticket">用户当前票据</param>
        /// <param name="name">姓名</param>
        /// <param name="gender">性别</param>
        /// <returns>true/false</returns>
        ComRet UpdateInfo(string ticket, string name, Gender gender);

        /// <summary>
        /// 更新用户手机号码
        /// </summary>
        /// <param name="ticket">用户当前票据</param>
        /// <param name="telphone">手机号码</param>
        /// <returns>true/false</returns>
        ComRet UpdateInfo(string ticket, string telphone);
    }
}
