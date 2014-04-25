using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;
using WinStudio.ComResult;
using WinStudio.iTrip.Business.Core;
using WinStudio.iTrip.Core;
using WinStudio.iTrip.Dto.Passport;
using WinStudio.iTrip.Framework;
using WinStudio.iTrip.ICore;
using WinStudio.iTrip.Models;
using WinStudio.iTrip.Permission.IPassport;

namespace WinStudio.iTrip.Permission.PassportService
{
    [AutofacServiceFlag(typeof(IProfile))]
    public class ProfileService : iTripBusiness, IProfile
    {
        public IUserSnap GetUserSnap(string ticket, LoginType type)
        {
            var passport = MongoEntity.Get<Passport>(p => p.SecurityKey == ticket);
            if (passport == null) return null;
            var profile = MongoEntity.Get<Profile>(p => p.SecurityKey == ticket);
            if (profile == null) return null;
            IUserSnap snap = new UserSnap()
            {
                Id = profile.Id,
                SecurityKey = profile.SecurityKey,
                Name = profile.Name,
                Account = profile.Account,
                LoginCode = passport.GetLoginCode(type),
                LoginType = type,
                Email = profile.Email,
                RegisteredTime = profile.BsonObjectId.CreationTime
            };
            Log(snap.Name + " do GetUserSnap");
            return snap;
            //return new UserInfo(profile.Id, profile.Account, profile.Name, profile.Email, (profile.Native == null ? "" : string.Format("{0}{1}{2}", profile.Region.Name, profile.Nationality.Name, profile.Native.Name)), DateTime.Now, profile.SecurityKey);
        }

        public ComRet Register(string passportid, string account, string name, string email)
        {
            if (MongoEntity.Exists<Profile>(p => p.Account == account))
                return Result("账户名称已存在");
            var profile = new Profile() { Id = passportid, Account = account, Name = name, Email = email };
            profile.SecurityKey = string.Format("{0}{1}{2}{3}{4}", profile.Id, profile.Account, profile.BsonObjectId.CreationTime.ToString("yyyyMMddHHmmss"), profile.BsonObjectId.Pid, profile.BsonObjectId.Timestamp).ToMD5(); //SecurityManager.Instance.GenSecurityKey(account, passport.Id);
            profile.Save();
            return Result(true, profile.Id);
        }


        public ComRet GetProfile(string id)
        {
            var profile = MongoEntity.Get<Profile>(id);
            if (profile == null) return Result("不存在的用户");
            Log("GetProfile");
            return Result(profile);
        }
        public ComRet CheckIn(string account, string password, LoginType type, string code)
        {
            var pp = MongoEntity.Get<Passport>(p => p.Account == account);
            if (pp == null) return Result("用户名不正确");
            if (pp.Password != password) return Result("密码不正确");
            if (type == LoginType.Web && pp.WebCode != code)
            {
                pp.WebCode = code;
                pp.Save();
            }
            else if (type != LoginType.Web && pp.ClientCode != code)
            {
                pp.ClientCode = code;
                pp.Save();
            }
            return Result(true, pp.SecurityKey);
        }

        public ComRet Register(string account, string password)
        {
            return Register(account, password, LoginType.Web);
        }

        public ComRet Register(string account, string password, LoginType origin)
        {
            if (MongoEntity.Exists<Passport>(p => p.Account == account))
                return Result("账户名已存在");
            var passport = new Passport(account, password, origin);
            passport.SecurityKey = string.Format("{0}{1}{2}{3}{4}", passport.Id, passport.Account, passport.BsonObjectId.CreationTime.ToString("yyyyMMddHHmmss"), passport.BsonObjectId.Pid, passport.BsonObjectId.Timestamp).ToMD5(); //SecurityManager.Instance.GenSecurityKey(account, passport.Id);
            passport.Save();
            return Result(true, passport.Id);
        }

    }
}
