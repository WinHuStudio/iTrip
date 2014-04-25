using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Service.Business.Relation.IRelationRecipient;
using iTrip.Service.Common.Wcf;
using iTrip.Service.Wcf.Passport.IAuthentication;
using iTrip.Service.Wcf.Relation.ITripperRelationShipResolver;

namespace iTrip.Service.Wcf.Relation.TripperRelationShipResolver
{
    [WinWcfService]
    public class RecipientShipManager : SuperWcfService, IRecipientShipManager
    {
        public StandardResult ApplyFriend(string applicant, string friend, string memo)
        {
            if (string.IsNullOrEmpty(applicant) || string.IsNullOrEmpty(friend))
                return Result(iTripExceptionCode.Error_Null_Reference);

            var wcf_auth = GetService<IServiceAuthenticationReception>();
            var names = wcf_auth.GetTripperNames(new string[] { applicant });
            if (names == null || names.Length != 1)
                return Result(iTripExceptionCode.Error_Wrong_Account);

            IRelationManager manager = new RelationManager();
            return manager.ApplyFriend(applicant, names[0], friend, memo);
        }

        public StandardResult AcceptApplication(string accepter, string applicationId)
        {
            if (string.IsNullOrEmpty(accepter) || string.IsNullOrEmpty(applicationId))
                return Result(iTripExceptionCode.Error_Null_Reference);

            IRelationManager manager = new RelationManager();
            return Result(manager.AcceptApplication(accepter, applicationId));
        }

        public StandardResult GetFriends(string account)
        {
            if (string.IsNullOrEmpty(account)) return Result(iTripExceptionCode.Error_Wrong_Account);
            IRelationManager manager = new RelationManager();
            return Result(manager.GetMyFriends(account));
        }
    }
}
