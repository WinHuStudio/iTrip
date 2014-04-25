using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Model;
using iTrip.Service.Business.Passport.IAuthentication;
using iTrip.Service.Common.Wcf;
using iTrip.Service.Passport.Business.Bll.Authentication;
using iTrip.Service.Wcf.Message.IPublisherIM;
using iTrip.Service.Wcf.Passport.IAuthentication;
using iTrip.Service.Wcf.Relation.ITripperRelationShipResolver;
using iTrip.Service.Wcf.Status.ITripperStatusResolver;

namespace iTrip.Service.Wcf.Passport.Authentication
{
    [WinWcfService]
    public class ServiceAuthenticationReception : SuperWcfService, IServiceAuthenticationReception
    {
        private IIdentification _iidentification;
        public StandardResult Register(string account, string password)
        {
            _iidentification = new Identification();
            var ret = _iidentification.Register(account, password);
            if (ret.Ret)
            {
                GetService<IPackageDelivery>().RegisterTripper(account, account);
                GetService<IRecipientRegistration>().RegisterTripper(account, account);
                GetService<ITripperStatusParser>().RegisterTripper(account, account);
            }
            return ret;
        }

        public StandardResult Logout(string ticket)
        {
            _iidentification = new Identification();
            return _iidentification.Logout(ticket);
        }

        public StandardResult Login(string account, string password, DeviceType device_type, string device_sn)
        {
            _iidentification = new Identification();
            return _iidentification.Login(account, password, device_type, device_sn);
        }

        public StandardResult CheckTicket(string ticket)
        {
            _iidentification = new Identification();
            return _iidentification.Check(ticket);
        }

        public StandardResult UpdateInfo(string ticket, Gender gender)
        {
            _iidentification = new Identification();
            return _iidentification.UpdateGender(ticket, gender);
        }

        public StandardResult UpdateTelphone(string ticket, string telphone)
        {
            _iidentification = new Identification();
            return _iidentification.UpdatePhone(ticket, telphone);
        }


        public string[] GetTripperNames(string[] ary_str_account)
        {
            if (ary_str_account == null || ary_str_account.Length == 0) return new string[0];

            _iidentification = new Identification();
            return _iidentification.GetTripperName(ary_str_account);
        }
    }
}
