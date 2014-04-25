using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Service.Business.Passport.IAuthentication
{
    public interface IIdentification
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码（密码在客户端进行md5加密）</param>
        /// <returns></returns>
        StandardResult Register(string account, string password);
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码（密码在客户端进行md5加密）</param>
        /// <param name="devicetype">设备类型</param>
        /// <param name="devicesn">设备串号</param>
        /// <returns>结果中包含有效票据</returns>
        StandardResult Login(string account, string password, DeviceType devicetype, string devicesn);
        /// <summary>
        /// 验证票据
        /// </summary>
        /// <param name="ticket">票据</param>
        /// <returns></returns>
        StandardResult Check(string ticket);
        /// <summary>
        /// 用户退出
        /// </summary>
        /// <param name="ticket">票据</param>
        /// <returns></returns>
        StandardResult Logout(string ticket);
        /// <summary>
        /// 更新性别
        /// </summary>
        /// <param name="ticket">票据</param>
        /// <param name="gender">性别</param>
        /// <returns></returns>
        StandardResult UpdateGender(string ticket, Gender gender);
        /// <summary>
        /// 更新设备手机号码
        /// </summary>
        /// <param name="ticket">票据</param>
        /// <param name="phone">手机号码</param>
        /// <returns></returns>
        StandardResult UpdatePhone(string ticket, string phone);
        /// <summary>
        /// 更新手机号码通讯录（只更新有变化的通讯录）
        /// </summary>
        /// <param name="ticket">票据</param>
        /// <param name="telphones">通讯录手机号码，使用字符‘|’隔开</param>
        /// <returns></returns>
        StandardResult UpdateContactBook(string ticket, string telphones);

        /// <summary>
        /// 获取账号的姓名
        /// </summary>
        /// <param name="ary_str_account">账号列表</param>
        /// <returns>姓名列表[格式：account|name]</returns>
        string[] GetTripperName(string[] ary_str_account);
    }
}
