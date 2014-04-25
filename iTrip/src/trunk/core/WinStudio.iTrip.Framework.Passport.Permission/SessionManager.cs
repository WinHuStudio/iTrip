using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.iTrip.Framework.Passport.IPermission;
using WinStudio.iTrip.ICore;

namespace WinStudio.iTrip.Framework.Passport.Permission
{
    public class SessionManager : ISessionManager
    {
        private List<ISessionSnap> _session_snaps = new List<ISessionSnap>();

        private int _timeout = 20;
        public SessionManager(int timeout = 0)
        {
            _timeout = timeout;
        }

        private void Refresh()
        {
            if (_timeout > 0)
            {
                DateTime expiredtime = DateTime.Now.AddMinutes(-_timeout);
                _session_snaps.RemoveAll(s => s.LastTime <= expiredtime);
            }
        }

        public void Expire(string securityToken)
        {
        }

        public IUserSnap Get(string securitykey)
        {
            Refresh();
            var session = _session_snaps.SingleOrDefault(s => s.UserSnap.SecurityKey == securitykey);
            if (session == null) return null;
            return session.UserSnap;
        }

        public bool IsExpired(string securitykey)
        {
            Refresh();
            var session = _session_snaps.SingleOrDefault(s => s.UserSnap.SecurityKey == securitykey);
            if (session == null) return true;
            session.LastTime = DateTime.Now;
            return true;
        }

        public bool IsLegal(string securityToken)
        {
            throw new NotImplementedException();
        }

        public string Add(IUserSnap snap)
        {
            Refresh();
            ISessionSnap session = _session_snaps.SingleOrDefault(s => s.UserSnap.SecurityKey == snap.SecurityKey);
            if (session == null)
            {
                session = new SessionSnap(snap);
                _session_snaps.Add(session);
            }
            return session.SecurityToken;
        }
        public string GetSecurityToken(string securitykey)
        {
            Refresh();
            ISessionSnap session = _session_snaps.SingleOrDefault(s => s.UserSnap.SecurityKey == securitykey);
            if (session == null) return string.Empty;
            return session.SecurityToken;
        }

        public List<IUserSnap> GetAllUser()
        {
            Refresh();
            return _session_snaps.Select(s => s.UserSnap).ToList();
        }

        public List<ICore.IUserSnap> GetValidUsers()
        {
            throw new NotImplementedException();
        }

        public List<ICore.IUserSnap> GetLegalUsers()
        {
            throw new NotImplementedException();
        }

        public int CountAll()
        {
            Refresh();
            return _session_snaps.Count();
        }

        public int CountLegal()
        {
            throw new NotImplementedException();
        }

        public int CountValid()
        {
            throw new NotImplementedException();
        }


        public void SetTimeout(int timeout)
        {
            _timeout = timeout;
        }


        public bool IsValid(IUserSnap snap)
        {
            ISessionSnap session = _session_snaps.SingleOrDefault(s => s.UserSnap.SecurityKey == snap.SecurityKey);
            return session.IsValidUser(snap);
        }
    }
}
