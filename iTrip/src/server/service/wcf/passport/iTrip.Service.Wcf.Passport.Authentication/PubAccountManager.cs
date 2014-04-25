using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Service.Business.Passport.Authentication;
using iTrip.Service.Business.Passport.IAuthentication;
using iTrip.Service.Common.Wcf;
using iTrip.Service.Passport.Business.Bll.Authentication;
using iTrip.Service.Wcf.Passport.IAuthentication;
using iTrip.Service.Wcf.Relation.ITripperRelationShipResolver;
using iTrip.TripperCenter;

namespace iTrip.Service.Wcf.Passport.Authentication
{
    public class PubAccountManager : SuperWcfService, IPubAccountManager
    {
        public StandardResult RegisterComAcc(string account, PubAccountType acctype)
        {
            if (string.IsNullOrEmpty(account)) return Result(iTripExceptionCode.Error_Null_Account);
            IPubAccount ipubaccount = new PubAccount();
                IRecipientRegistration registration = GetService<IRecipientRegistration>();
            StandardResult result;
            switch (acctype)
            {
                case PubAccountType.Group:
                    result = ipubaccount.RegisterGroup(account);
                    break;
                case PubAccountType.Publisher:
                    result = ipubaccount.RegisterPublisher(account);
                    break;
                case PubAccountType.Community:
                    result = ipubaccount.RegisterCommunity(account);
                    break;
                case PubAccountType.Organization:
                    result = ipubaccount.RegisterOrganization(account);
                    break;
                default:
                    result = Result(iTripExceptionCode.Error_UnKnown);
                    break;
            }
            //if (result.Ret)
            //{
            //    registration.RegisterGroup
            //}
            return result;
        }
    }
}
