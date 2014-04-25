using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.iTrip.Framework.IPermission;

namespace WinStudio.iTrip.Framework
{

    public class UserInfo : IUserInfo
    {
        public UserInfo(string id, string account, string name, string email, string nationnative, DateTime logintime, string securitykey)
        {
            _id = id;
            _name = name;
            _account = account;
            _email = email;
            _nana = nationnative;
            _logintime = logintime;
            _securitykey = securitykey;
        }
        private string _id, _account, _name, _email, _nana, _ip, _securitykey;
        private DateTime _logintime;
        public string Id { get { return _id; } }
        public string Account { get { return _account; } }
        public string Name { get { return _name; } }
        public string Email { get { return _email; } }

        public string NationNative { get { return _nana; } }
        public DateTime LoginTime { get { return _logintime; } }

        public string IP { get { return _ip; } }
        public string SecurityKey { get { return _securitykey; } }


        public void InitIP(string ip)
        {
            if (string.IsNullOrEmpty(_ip)) return;
            _ip = ip;
        }
    }
}
