using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WinStudio.iTrip.Core;
using WinStudio.iTrip.Framework.Passport.IPermission;
using WinStudio.iTrip.ICore;
using WinStudio.iTrip.Models;

namespace WinStudio.iTrip.Framework.Passport.Permission
{
    public class Reception : IReception
    {
        private ISessionManager _session_manager;
        private IUserSnapLoader _usersnap_loader;
        private IUserPermissionLoader _userpermission_loader;
        //private int _timeout = 0;

        private static IReception _instance = new Reception();
        public static IReception Instance
        {
            get
            {
                return _instance;
            }
        }

        public Reception()
            : this(0, null)
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="timeout">0为不设置过期</param>
        /// <param name="userSnapLoader">用户加载器</param>
        public Reception(int timeout, IUserSnapLoader userSnapLoader)
        {
            _session_manager = new SessionManager(timeout);
            _usersnap_loader = userSnapLoader;
        }


        public bool IsAuthorized(IUserSnap user)
        {
            IUserSnap snap = GetUser(user.SecurityKey, user.LoginType);
            if (snap == null) return false;
            return _session_manager.IsValid(user);
        }

        public IUserSnap GetUser(string securitytoken, LoginType type)
        {
            IUserSnap snap = _session_manager.Get(securitytoken);
            if (snap == null)
            {
                _usersnap_loader.SetResource(WebConfiguration.Instance.WebUpdateUserAddress);
                snap = _usersnap_loader.Load(securitytoken, type);
                if (snap == null) return snap;
                _session_manager.Add(snap);
            }
            return snap;
        }

        public void SetUserSnapLoader(IUserSnapLoader loader)
        {
            _usersnap_loader = loader;
        }

        public void SetTimeout(int timeout)
        {
            _session_manager.SetTimeout(timeout);
        }

        public bool ValidPermission(string account, string securitytoken, string resource, NameValueCollection keyvalues)
        {
            if (_userpermission_loader == null) return true;
            return false;
        }

        public void SetUserPermissionLoader(IUserPermissionLoader loader)
        {
            _userpermission_loader = loader;
        }

        public void SaveCookies(HttpContextBase context, IUserSnap user)
        {
            context.SaveCookie(WebConfiguration.Instance.ConfigAccountTokenName, user.Account, WebConfiguration.Instance.ConfigDomainName);
            context.SaveCookie(WebConfiguration.Instance.ConfigIdTokenName, user.Id, WebConfiguration.Instance.ConfigDomainName);
            context.SaveCookie(WebConfiguration.Instance.ConfigSecurityTokenName, user.SecurityKey, WebConfiguration.Instance.ConfigDomainName);
        }

        public bool IsAuthorized(HttpContextBase context, LoginType type)
        {
            var _id = context.GetToken(WebConfiguration.Instance.ConfigIdTokenName);
            var _account = context.GetToken(WebConfiguration.Instance.ConfigAccountTokenName);
            var _securitykey = context.GetToken(WebConfiguration.Instance.ConfigSecurityTokenName);

            if (string.IsNullOrEmpty(_id) || string.IsNullOrEmpty(_account) || string.IsNullOrEmpty(_securitykey))
                return false;
            var _code = string.Empty;
            if (type == LoginType.Web)
                _code = context.GetIP();
            else _code = context.GetHeader(WebConfiguration.Instance.ConfigHeaderCodeName);

            var snap = new UserSnap() { Id = _id, Account = _account, SecurityKey = _securitykey, LoginType = type, LoginCode = _code };
            return Reception.Instance.IsAuthorized(snap);
        }

        public void Logout(HttpContextBase context)
        {
            var _securitykey = context.GetToken(WebConfiguration.Instance.ConfigSecurityTokenName);
            if (string.IsNullOrEmpty(_securitykey)) return;
            Logout(_securitykey);
        }

        public void Logout(string securitytoken)
        {
            _session_manager.Expire(securitytoken);
        }
    }
}
