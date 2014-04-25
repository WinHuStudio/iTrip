using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AutofacAutoResolver;
using WinStudio.iTrip.Core;
using WinStudio.iTrip.Framework.Passport.IPermission;
using WinStudio.iTrip.Framework.Passport.Permission;
using WinStudio.iTrip.ICore;
using WinStudio.iTrip.Models;
using WinStudio.iTrip.Permission.IPassport;
using WinStudio.iTrip.Permission.PassportService;

namespace WinStudio.iTrip.Web.Core.Permission
{
    public class iTripWebUserSnapLoader : IUserSnapLoader
    {
        private string _resource;

        public IUserSnap Load(string securityToken, LoginType type)
        {
            CookieContainer cc = new CookieContainer();

            Cookie ck = new Cookie(WebConfiguration.Instance.ConfigSecurityTokenName, securityToken);
            ck.Domain = string.IsNullOrEmpty(WebConfiguration.Instance.ConfigDomainName) ? "localhost" : WebConfiguration.Instance.ConfigDomainName;
            cc.Add(ck);

            string ret = HttpHelper.SendRequest(_resource, null, cc, "POST", "utf-8");
            if (string.IsNullOrEmpty(ret)) return null;
            return ret.ToObject<UserSnap>(Encoding.UTF8);
        }

        public void SetResource(string resource)
        {
            _resource = resource;
        }
    }
}
