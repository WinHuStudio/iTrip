using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Service.Wcf.Passport.IAuthentication
{
    /// <summary>
    /// 认证服务接口
    /// </summary>
    [ServiceContract]
    public interface IServiceAuthenticationReception
    {
        /// <summary>
        /// 用户注册（无登录功能）
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码（MD5加密）</param>
        /// <returns>true/false</returns>
        [OperationContract]
        StandardResult Register(string account, string password);

        /// <summary>
        /// 用户登出（服务端只改变用户状态为offline，客户端需要移除当前有效票据）
        /// </summary>
        /// <param name="ticket">票据</param>
        /// <returns>true/false</returns>
        [OperationContract]
        StandardResult Logout(string ticket);

        /// <summary>
        /// 用户登录（改变用户状态为online，并返回用户票据）
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码（MD5加密）</param>
        /// <param name="device_type">登录客户端类型</param>
        /// <param name="device_sn">登录客户端标识</param>
        /// <returns>Json{ret=true/false,msg=ticket}</returns>
        [OperationContract]
        StandardResult Login(string account, string password, DeviceType device_type, string device_sn);

        /// <summary>
        /// 检查用户票据
        /// </summary>
        /// <param name="ticket">票据</param>
        /// <returns>true/false</returns>
        [OperationContract]
        StandardResult CheckTicket(string ticket);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="ticket">用户当前票据</param>
        /// <param name="gender">性别</param>
        /// <returns>true/false</returns>
        [OperationContract]
        StandardResult UpdateInfo(string ticket, Gender gender);

        /// <summary>
        /// 更新用户手机号码
        /// </summary>
        /// <param name="ticket">用户当前票据</param>
        /// <param name="telphone">手机号码</param>
        /// <returns>true/false</returns>
        [OperationContract]
        StandardResult UpdateTelphone(string ticket, string telphone);

        /// <summary>
        /// 获取账号的姓名
        /// </summary>
        /// <param name="ary_str_account">账号列表</param>
        /// <returns>姓名列表</returns>
        string[] GetTripperNames(string[] ary_str_account);
    }
}
