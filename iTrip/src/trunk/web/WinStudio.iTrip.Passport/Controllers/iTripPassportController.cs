using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinStudio.iTrip.Framework.Passport.Permission;
using WinStudio.iTrip.ICore;
using WinStudio.iTrip.Models;
using WinStudio.iTrip.Permission.IPassport;

namespace WinStudio.iTrip.Passport.Controllers
{
    public class iTripPassportController : iTripWebController
    {
        protected void CheckIn(string account, string securitykey, LoginType type, string code)
        {
            var user = GetService<IProfile>().GetUserSnap(securitykey, type);
            user.LoginType = type;
            user.LoginCode = code;
            if (user == null || user.Account != account) return;
            //IUserInfo user = new UserInfo() { Id = userinfo.Id, Account = userinfo.Account, Name = userinfo.Name, Email=userinfo.Email, Origin= userinfo.Origin, RegisterdTime = userinfo. };
            if (Reception.Instance.IsAuthorized(user))
                Reception.Instance.SaveCookies(HttpContext, user);
            Log(user.Name + " Checked In");

            //WinWebGlobalManager.Reception.Login(HttpContext, user);

            //var key = string.Format("{0}_{1}_{2}", profile.Account, DateTime.Now.ToString("yyyyMMddHHmmssffff"), profile.Id).ToMD5();
            //HttpContext.SaveCookie(Consts.CookieName, key, Consts.CookieDomain, Consts.CookieTimeout);
            //HttpContext.SaveToSession(key, profile);
        }

        protected string GetUserInfo()
        {
            var key = HttpContext.GetToken(WebConfiguration.Instance.ConfigSecurityTokenName);


            if (string.IsNullOrEmpty(key)) return string.Empty;

            IUserSnap user = Reception.Instance.GetUser(key, LoginType.Web);
            //IUserInfo user = WinWebGlobalManager.Reception.GetUserInfo(key);
            if (user == null)
                user = GetService<IProfile>().GetUserSnap(key, LoginType.Web);
            if (user == null) return string.Empty;
            //WinWebGlobalManager.Reception.Sign(HttpContext, user);
            string _u = user.ToXml();
            return _u;
        }

        protected bool ValidateToken()
        {
            LoginType type = HttpContext.GetHeader(WebConfiguration.Instance.ConfigHeaderCodeName).ToEnum<LoginType>(LoginType.Web);
            return Reception.Instance.IsAuthorized(HttpContext, type);
        }

        protected void DoLogout()
        {
            Reception.Instance.Logout(HttpContext);
        }
    }
}
