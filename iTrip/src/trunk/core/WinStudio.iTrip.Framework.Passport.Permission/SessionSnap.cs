using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.iTrip.Framework.Passport.IPermission;
using WinStudio.iTrip.ICore;

namespace WinStudio.iTrip.Framework.Passport.Permission
{
    public class SessionSnap : ISessionSnap
    {
        private string _securityToken = string.Empty;

        public SessionSnap(IUserSnap user)
        {
            UserSnap = user;
            LastTime = DateTime.Now;
            //SecurityToken = user.SecurityKey;
            _securityToken = string.Format("{0}{1}{2}", user.Id, user.Account, user.LoginCode).ToMD5();
        }

        public IUserSnap UserSnap { get; set; }

        public DateTime LastTime { get; set; }

        public string SecurityToken { get { return _securityToken; } }

        public bool IsValidUser(IUserSnap snap)
        {
            return _securityToken.Equals(string.Format("{0}{1}{2}", snap.Id, snap.Account, snap.LoginCode).ToMD5());
        }
    }
}
