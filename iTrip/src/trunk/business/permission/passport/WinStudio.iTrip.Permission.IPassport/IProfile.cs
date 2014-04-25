using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.ComResult;
using WinStudio.iTrip.ICore;
using WinStudio.iTrip.Models;
using WinStuido.iTrip.Business.ICore;

namespace WinStudio.iTrip.Permission.IPassport
{
    public interface IProfile : ITripBusiness
    {
        /// <summary>
        /// 获取用户快照
        /// </summary>
        /// <param name="securitykey"></param>
        /// <returns></returns>
        IUserSnap GetUserSnap(string securitykey, LoginType type);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        ComRet GetProfile(string id);

        /// <summary>
        /// 注册Profile
        /// </summary>
        /// <param name="passportid">id</param>
        /// <param name="account">账号</param>
        /// <param name="name">姓名</param>
        /// <param name="email">email</param>
        /// <returns></returns>
        ComRet Register(string passportid, string account, string name, string email);

        /// <summary>
        /// 用户认证
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <param name="type">登录类型</param>
        /// <param name="code">登录代码</param>
        /// <returns></returns>
        ComRet CheckIn(string account, string password, LoginType type, string code);

        /// <summary>
        /// 注册Passport（Web注册）
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        ComRet Register(string account, string password);

        /// <summary>
        /// 注册Passport（Web注册）
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <param name="origin">认证方式</param>
        /// <returns></returns>
        ComRet Register(string account, string password, LoginType origin);
    }
}
