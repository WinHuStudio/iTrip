using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WinStudio.iTrip.Framework.Passport.Permission;
using WinStudio.iTrip.ICore;
using WinStudio.iTrip.Models;

namespace System.Web
{
    public static class Extensions
    {
        public static bool IsLogin(this HttpContext context)
        {
            HttpContextBase basecontext = context.ToBase();
            //NameValueCollection nvc = new NameValueCollection();
            //nvc.Add(WebConfiguration.Instance.ConfigHeaderTypeName, LoginType.Web.ToString());
            //nvc.Add(WebConfiguration.Instance.ConfigHeaderCodeName, basecontext.GetIP());
            //context.Request.Headers.Add(WebConfiguration.Instance.ConfigHeaderTypeName, LoginType.Web.ToString());
            //context.Request.Headers.Add(WebConfiguration.Instance.ConfigHeaderCodeName, basecontext.GetIP());
            return Reception.Instance.IsAuthorized(basecontext, LoginType.Web);
        }
        public static string MyName(this HttpContext context)
        {
            var me = context.Me();
            if (me == null) return string.Empty;
            return me.Name;
        }
        public static string MyAccount(this HttpContext context)
        {
            var me = context.Me();
            if (me == null) return string.Empty;
            return me.Account;
        }
        public static string MyID(this HttpContext context)
        {
            var me = context.Me();
            if (me == null) return string.Empty;
            return me.Id;
        }
        public static IUserSnap Me(this HttpContext context)
        {
            var token = context.GetCookieValue(WebConfiguration.Instance.ConfigSecurityTokenName);
            return Reception.Instance.GetUser(token, LoginType.Web);
        }

        //internal static bool IsAuthorizedContext(this HttpContextBase context)
        //{
        //    string account = context.GetToken(_config.ConfigAccountTokenName);
        //    string id = context.GetToken(_config.ConfigIdTokenName);
        //    string security = context.GetToken(_config.ConfigSecurityTokenName);
        //    if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(security))
        //        return false;
        //}
    }
}
