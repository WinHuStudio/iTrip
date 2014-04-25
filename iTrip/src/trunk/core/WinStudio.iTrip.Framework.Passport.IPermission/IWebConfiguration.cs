using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStudio.iTrip.Framework.Passport.IPermission
{
    public interface IWebConfiguration
    {
        string ConfigAccountTokenName { get; }

        string ConfigIdTokenName { get; }

        string ConfigSecurityTokenName { get; }

        string ConfigHeaderCodeName { get; }

        string ConfigHeaderTypeName { get; }

        string ConfigHeaderBusiCodeName { get; }

        string ConfigDomainName { get; }

        int ConfigTimeout { get; }

        string WebProtalAddress { get; }

        string WebLoginAddress { get; }

        string WebUpdateUserAddress { get; }

        string WebLogoutAddress { get; }

        string WebPassportAddress { get; }

        string WebRegisterAddress { get; }

        void Reset(string tokenAccount, string tokenId, string tokenSecurity, string headercode, string headertype, string headerbusicode, string domain, int timeout);
        void Reset(string protaladdr, string passportaddr, string loginaddr, string logoutaddr, string registeraddr, string updateuseraddr, string updatepermissioinaddr);

    }
}
