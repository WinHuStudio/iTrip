using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using iTrip.Service.Wcf.Relation.ITripperRelationShipResolver;
using iTrip.Web.Common.Security;

namespace iTrip.Web.Controllers
{
    [iTripValidationWithVSN_WMD_AUT]
    public class RelationController : iTripController
    {
        public ActionResult ApplyFriend(string friend, string memo)
        {
            var serv = WcfHost_Relation.GetService<IRecipientShipManager>();
            return JResult(serv.ApplyFriend(Account, friend, memo));
        }
        public ActionResult AcceptFriend(string appId)
        {
            var serv = WcfHost_Relation.GetService<IRecipientShipManager>();
            return JResult(serv.AcceptApplication(Account, appId));
        }

        public ActionResult GetFriends()
        {
            var serv = WcfHost_Relation.GetService<IRecipientShipManager>();
            return JResult(serv.GetFriends(Account));
        }
    }
}
