using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.iTrip.Framework.Passport.IPermission;

namespace WinStudio.iTrip.Framework.Passport.Permission
{
    public class WebConfiguration : IWebConfiguration
    {
        private string _configAccountTokenName, _configIdTokenName, _configSecurityTokenName, _configHeaderBusiCodeName, _configDomainName, _configHeaderCodeName, _configHeaderTypeName;
        private string _webProtalAddress, _webLoginAddress, _webUpdateUserAddress, _webUpdatePermissionAddress, _webLogoutAddress, _webPassportAddress, _webRegisterAddress;
        private int _configTimeout = 0;

        private static IWebConfiguration _instance = new WebConfiguration();
        public static IWebConfiguration Instance
        {
            get
            {
                return _instance;
            }
        }

        //public WebConfiguration(string tokenAccount, string tokenId, string tokenSecurity, string domain, int timeout)
        //{
        //    _configAccountTokenName = tokenAccount;
        //    _configIdTokenName = tokenId;
        //    _configSecurityTokenName = tokenSecurity;
        //    _configDomainName = domain;
        //    _configTimeout = timeout;
        //}

        public string ConfigAccountTokenName
        {
            get { return _configAccountTokenName; }
        }

        public string ConfigIdTokenName
        {
            get { return _configIdTokenName; }
        }

        public string ConfigSecurityTokenName
        {
            get { return _configSecurityTokenName; }
        }
        public string WebName
        {
            get { return _configDomainName; }
        }
        public string ConfigDomainName
        {
            get { return _configDomainName; }
        }

        public int ConfigTimeout
        {
            get { return _configTimeout; }
        }


        public void Reset(string tokenAccount, string tokenId, string tokenSecurity,
            string headercode, string headertype, string protaladdr, string loginaddr, string updateuseraddr, string updatepermissioinaddr, string headerbusicode,
            string domain, int timeout)
        {
            _configAccountTokenName = tokenAccount;
            _configIdTokenName = tokenId;
            _configSecurityTokenName = tokenSecurity;
            _configDomainName = domain;
            _configTimeout = timeout;

            _configHeaderCodeName = headercode;
            _configHeaderTypeName = headertype;
            _webProtalAddress = protaladdr;
            _webLoginAddress = loginaddr;
            _webUpdateUserAddress = updateuseraddr;
            _webUpdatePermissionAddress = updatepermissioinaddr;
            _configHeaderBusiCodeName = headerbusicode;
        }

        public string ConfigHeaderCodeName
        {
            get { return _configHeaderCodeName; }
        }

        public string ConfigHeaderTypeName
        {
            get { return _configHeaderTypeName; }
        }

        public string WebProtalAddress
        {
            get { return _webProtalAddress; }
        }

        public string WebLoginAddress
        {
            get { return _webLoginAddress; }
        }
        public string WebUpdateUserAddress
        {
            get { return _webUpdateUserAddress; }
        }
        public string WebUpdatePermissionAddress
        {
            get { return _webUpdatePermissionAddress; }
        }

        public string ConfigHeaderBusiCodeName
        {
            get { return _configHeaderBusiCodeName; }
        }


        public string WebLogoutAddress
        {
            get { return _webLogoutAddress; }
        }

        public string WebPassportAddress
        {
            get { return _webPassportAddress; }
        }
        public string WebRegisterAddress
        {
            get { return _webRegisterAddress; }
        }

        public void Reset(string tokenAccount, string tokenId, string tokenSecurity, string headercode, string headertype, string headerbusicode, string domain, int timeout)
        {
            _configAccountTokenName = tokenAccount;
            _configIdTokenName = tokenId;
            _configSecurityTokenName = tokenSecurity;
            _configDomainName = domain;
            _configTimeout = timeout;

            _configHeaderCodeName = headercode;
            _configHeaderTypeName = headertype;
            _configHeaderBusiCodeName = headerbusicode;
        }

        public void Reset(string protaladdr, string passportaddr, string loginaddr, string logoutaddr, string registeraddr, string updateuseraddr, string updatepermissioinaddr)
        {
            _webProtalAddress = protaladdr;
            _webLoginAddress = loginaddr;
            _webUpdateUserAddress = updateuseraddr;
            _webUpdatePermissionAddress = updatepermissioinaddr;
            _webLogoutAddress = logoutaddr;
            _webPassportAddress = passportaddr;
            _webRegisterAddress = registeraddr;
        }
    }
}
