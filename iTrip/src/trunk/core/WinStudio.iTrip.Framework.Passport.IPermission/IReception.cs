using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WinStudio.iTrip.ICore;
using WinStudio.iTrip.Models;

namespace WinStudio.iTrip.Framework.Passport.IPermission
{
    public interface IReception
    {
        void SetUserSnapLoader(IUserSnapLoader loader);

        void SetUserPermissionLoader(IUserPermissionLoader loader);

        void SetTimeout(int timeout);

        bool IsAuthorized(HttpContextBase context, LoginType type);
        bool IsAuthorized(IUserSnap user);

        IUserSnap GetUser(string securitytoken, LoginType type);

        bool ValidPermission(string account, string securitytoken, string resource, NameValueCollection keyvalues);

        void SaveCookies(HttpContextBase context, IUserSnap user);

        void Logout(HttpContextBase context);
        void Logout(string securitytoken);
    }
}
