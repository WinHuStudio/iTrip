using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Core.Security;
using iTrip.Model;
using iTrip.Service.Business.Passport.IAuthentication;
using iTrip.Service.Common;
using iTrip.TripperCenter;

namespace iTrip.Service.Passport.Business.Bll.Authentication
{
    public class Identification : SuperBllService, IIdentification
    {
        public StandardResult Register(string account, string password)
        {
            var resp = GetRespository<PassPhrase>();
            if (resp.Exists(p => p.Account == account))
                return Result(iTripExceptionCode.Error_Exist_Account);
            resp.Save(new PassPhrase(account, password));
            return Result();
        }

        public StandardResult Login(string account, string password, DeviceType devicetype, string devicesn)
        {
            var resp = GetRespository<PassPhrase>();
            var pp = resp.Get(p => p.Account == account);
            if (pp == null) return Result(iTripExceptionCode.Error_Null_Account);
            if (pp.Password != password) return Result(iTripExceptionCode.Error_Wrong_Password);
            if (pp.IsFirst)
            {
                pp.DeviceType = devicetype;
                pp.DeviceSN = devicesn;
                pp.Ticket = TicketGenerator.Instance.GenTicket(pp.Account, pp.DeviceSN);
                resp.Save(pp);
                return Result(true, pp.Ticket);
            }
            else
            {
                if (pp.DeviceSN != devicesn)
                    return Result(iTripExceptionCode.Error_Wrong_DeviceSN);
                return Result(true, pp.Ticket);
            }
        }

        public StandardResult Check(string ticket)
        {
            var resp = GetRespository<PassPhrase>();
            if (resp.Exists(p => p.Ticket == ticket))
                return Result();
            return Result(iTripExceptionCode.Error_Illegal_Ticket);
        }

        public StandardResult Logout(string ticket)
        {
            return Result();
        }

        public StandardResult UpdateGender(string ticket, Gender gender)
        {
            var resp = GetRespository<PassPhrase>();
            var pp = resp.Get(p => p.Ticket == ticket);
            if (pp == null) return Result(iTripExceptionCode.Error_Null_Account);
            if (pp.Gender != Gender.Unknown)
            {
                pp.Gender = gender;
                resp.Save(pp);
                return Result();
            }
            return Result(iTripExceptionCode.Error_Illegal_Operation_Gender);
        }

        public StandardResult UpdatePhone(string ticket, string phone)
        {
            var respa = GetRespository<PassPhrase>();
            var pp = respa.Get(p => p.Ticket == ticket);
            if (pp == null) return Result(iTripExceptionCode.Error_Null_Account);
            var respb = GetRespository<Profile>();
            var pro = respb.Get(p => p.Account == pp.Account);
            pro.Telphone = phone;
            respb.Save(pro);
            return Result();
        }

        public StandardResult UpdateContactBook(string ticket, string telphones)
        {
            return Result(false);
        }


        public string[] GetTripperName(string[] ary_str_account)
        {
            var resp_profile = GetRespository<Profile>();
            var names = resp_profile.Select(p => ary_str_account.Contains(p.Account)).Select(p => string.Format("{0}|{1}", p.Account, p.Name)).ToArray();
            return names;
        }
    }
}
