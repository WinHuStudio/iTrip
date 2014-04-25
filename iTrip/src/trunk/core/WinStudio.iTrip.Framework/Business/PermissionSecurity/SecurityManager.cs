using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace WinStudio.iTrip.Framework.Business.PermissionSecurity
{
    public class iTripSecurityManager : IiTripSecurityManager
    {
        //private static IiTripSecurityManager _instance = new iTripSecurityManager();
        //public static IiTripSecurityManager Instance { get { return _instance; } }

        public string GenDynamicToken(IUserInfo user, string code)
        {
            //if (user.IP.Length < 7) throw new Exception("Wrong Ip Address:" + userinfo.IP);
            var key = string.Format("{0}{1}{2}", GenSecurityKey(user), user.Id, code.ToMD5());
            return string.Format("{0}{1}", key.ToMD5(), key.ToSHA1());
        }

        public string GenSecurityKey(IUserInfo user)
        {
            ObjectId _uid;
            if (!ObjectId.TryParse(user.Id, out _uid)) throw new Exception("Wrong uid");
            var key = string.Format("{0}{1}{2}{3}{4}", user.Account, user.Name, user.Email, _uid.Pid, _uid.CreationTime.ToString("yyyyMMddHHmmss"));
            return string.Format("{0}{1}", key.ToMD5(), key.ToSHA1());
        }

        public bool ValidDynamicToken(IUserInfo user, string code, string dynamictoken)
        {
            if (string.IsNullOrEmpty(dynamictoken)) return false;
            return dynamictoken.Equals(GenDynamicToken(user, code));
        }

        public bool ValidSecurityKey(IUserInfo user, string securitykey)
        {
            if (string.IsNullOrEmpty(securitykey)) return false;
            return securitykey.Equals(GenSecurityKey(user));

        }
    }
}
