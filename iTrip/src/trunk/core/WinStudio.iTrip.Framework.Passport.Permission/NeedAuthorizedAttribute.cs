using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WinStudio.iTrip.Models;

namespace WinStudio.iTrip.Framework.Passport.Permission
{
    public class NeedAuthorizedAttribute : AuthorizeAttribute
    {
        public virtual string JumpConnector { get { return "next"; } }
        public virtual bool NeedBase64EncryptJumpUrl { get { return true; } }
        public virtual Encoding Encoding { get { return Encoding.UTF8; } }
        //public string HandlePermissionAddress { get { return WinWebGlobalManager.Config.WinHandleUnAuthorizedAddress} }
        public string HandleUnauthorizedAddress { get { return WebConfiguration.Instance.WebLoginAddress; } }
        public bool DoValidPermissioin(string account, string securitytoken, string resource, NameValueCollection keyvalues)
        {
            return Reception.Instance.ValidPermission(account, securitytoken, resource, keyvalues);
        }
        private LoginType _logintype = LoginType.Web;
        private string _id, _account, _securitykey, _code;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //_id = httpContext.GetToken(WebConfiguration.Instance.ConfigIdTokenName);
            //_account = httpContext.GetToken(WebConfiguration.Instance.ConfigAccountTokenName);
            //_securitykey = httpContext.GetToken(WebConfiguration.Instance.ConfigSecurityTokenName);

            //if (string.IsNullOrEmpty(_id) || string.IsNullOrEmpty(_account) || string.IsNullOrEmpty(_securitykey))
            //    return false;

            _logintype = httpContext.GetHeader(WebConfiguration.Instance.ConfigHeaderTypeName).ToEnum<LoginType>(LoginType.Web);
            //_code = httpContext.GetHeader(WebConfiguration.Instance.ConfigHeaderCodeName);

            return Reception.Instance.IsAuthorized(httpContext, _logintype);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AuthorizeCore(filterContext.HttpContext))
            {
                string busicode = filterContext.HttpContext.GetHeader(WebConfiguration.Instance.ConfigHeaderBusiCodeName);
                if (DoValidPermissioin(_account, _securitykey, filterContext.HttpContext.Request.Url.Query, busicode.ToNameValueCollection("=&")))
                    return;
            }
            HandleUnauthorizedRequest(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            if (_logintype == LoginType.Web)
            {
                var urlnext = NeedBase64EncryptJumpUrl ? Convert.ToBase64String(Encoding.GetBytes(filterContext.HttpContext.Request.Url.ToString())) : filterContext.HttpContext.Request.Url.ToString();
                var urllogin = string.Format("{0}?{1}={2}", HandleUnauthorizedAddress, JumpConnector, urlnext);
                RedirectResult ret = new RedirectResult(urllogin);
                filterContext.Result = ret;
            }
            else
            {
                filterContext.HttpContext.Response.Write(false);
                filterContext.HttpContext.Response.End();
            }
        }
    }
}
