using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Model;
using iTrip.Settings.Business.Permissions;
using iTrip.TripperCenter;
using MongoDB.Repository;
using WinStudio.ComResult;

namespace iTrip.Business.Authentication
{
    public class ServiceAuthentication : iTripBusiness, IServiceAuthentication
    {
        public ComRet Register(string account, string password)
        {
            if (MongoEntity.Exists<Passport>(p => p.Account == account))
            {
                return Result(false, "账户已存在");
            }
            Passport passport = new Passport(account, password);
            passport.Save();

            Profile profile = new Profile() { Account = passport.Account, Name = account };
            profile.Save();
            return Result(true);
        }

        public ComRet Login(string ticket)
        {
            return Result(MongoEntity.Exists<Passport>(p => p.Ticket == ticket));
        }

        public ComRet UpdateInfo(string ticket, string name, Gender gender)
        {
            var passport = MongoEntity.Get<Passport>(p => p.Ticket == ticket);
            if (passport == null) return Result(false, "账户不存在");
            var profile = MongoEntity.Get<Profile>(p => p.Account == passport.Account);

            profile.Name = name;
            profile.Gender = gender;
            profile.Save();
            return Result(true);
        }
        
        public ComRet Login(string account, string password, ClientType client, string client_sn)
        {
            var passport = MongoEntity.Get<Passport>(p => p.Account == account && p.Password == password);

            if (passport == null) return Result(false, "账户名不正确");

            Profile profile = MongoEntity.Get<Profile>(p => p.Account == account);

            if (profile == null) return Result(false, "账户不合法");

            profile.Client = client;
            profile.ClientSN = client_sn;
            profile.Save();

            passport.Ticket = BusinessAuthentication.GenTicket(profile);
            passport.Save();

            return Result(true, passport.Ticket);
        }

        public ComRet CheckTicket(string ticket)
        {
            return Result(MongoEntity.Exists<Passport>(p => p.Ticket == ticket));
        }


        public ComRet Logout(string ticket)
        {
            //todo:log
            return Result(true);
        }


        public ComRet UpdateInfo(string ticket, string telphone)
        {
            var passport = MongoEntity.Get<Passport>(p => p.Ticket == ticket);
            if (passport == null) return Result(false, "账户不存在");
            var profile = MongoEntity.Get<Profile>(p => p.Account == passport.Account);

            profile.Telphone = telphone;
            profile.Save();
            return Result(true);
        }
    }
}
