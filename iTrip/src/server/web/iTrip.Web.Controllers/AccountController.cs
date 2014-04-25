using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTrip.Model;
using iTrip.Service.Wcf.Passport.IAuthentication;
using iTrip.Web.Common.Security;

namespace iTrip.Web.Controllers
{
    public class AccountController : iTripController
    {

        /// <summary>
        /// 用户登录（改变用户状态为online，并返回用户票据）
        /// </summary>
        /// <param name="password">密码（MD5加密）</param>
        /// <returns>Json{ret=true/false,msg=ticket}</returns>
        [HttpPost]
        [iTripVSNValidationAnd(WebRequestFilterType.WebMethod)]
        public JsonResult Login(string password)
        {
            var ret = WcfHost_Passport.GetService<IServiceAuthenticationReception>().Login(Account, password, DeviceType, DeviceSN);
            return JResult(ret);
        }

        /// <summary>
        /// 检查用户票据
        /// </summary>
        /// <returns>true/false</returns>
        [HttpPost]
        [iTripValidationWithVSN_WMDAnd(WebRequestFilterType.Authentication)]
        public ActionResult CheckTicket()
        {
            var ret = WcfHost_Passport.GetService<IServiceAuthenticationReception>().CheckTicket(Ticket);
            return JResult(ret);
        }

        /// <summary>
        /// 用户登出（服务端只改变用户状态为offline，客户端需要移除当前有效票据）
        /// </summary>
        /// <returns>true/false</returns>
        [HttpPost]
        [iTripValidationWithVSN_WMDAnd(WebRequestFilterType.Authentication)]
        public ActionResult Logout()
        {
            var ret = WcfHost_Passport.GetService<IServiceAuthenticationReception>().Logout(Ticket);
            return JResult(ret);
        }

        /// <summary>
        /// 用户注册（无登录功能）
        /// </summary>
        /// <param name="password">密码（MD5加密）</param>
        /// <returns>true/false</returns>
        [HttpPost]
        [iTripVSNValidationAnd(WebRequestFilterType.WebMethod)]
        public ActionResult Register(string password)
        {
            try
            {
                var ret = WcfHost_Passport.GetService<IServiceAuthenticationReception>().Register(Account, password);
                return JResult(ret);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return JResult(false, e.Message);
            }
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="gender">性别</param>
        /// <returns>true/false</returns>
        [HttpPost]
        [iTripValidationWithVSN_WMDAnd(WebRequestFilterType.Authentication)]
        public ActionResult UpdateUserInfo(int gender)
        {
            var ret = WcfHost_Passport.GetService<IServiceAuthenticationReception>().UpdateInfo(Ticket, (Gender)gender);
            return JResult(ret);
        }

        /// <summary>
        /// 更新用户手机号码
        /// </summary>
        /// <param name="telphone">手机号码</param>
        /// <returns>true/false</returns>
        [HttpPost]
        [iTripValidationWithVSN_WMDAnd(WebRequestFilterType.Authentication)]
        public ActionResult UpdateTelphone(string telphone)
        {
            var ret = WcfHost_Passport.GetService<IServiceAuthenticationReception>().UpdateTelphone(Ticket, telphone);
            return JResult(ret);
        }

    }
}
