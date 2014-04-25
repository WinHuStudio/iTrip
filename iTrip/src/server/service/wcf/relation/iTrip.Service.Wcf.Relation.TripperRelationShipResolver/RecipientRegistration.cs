using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Service.Business.Passport.IAuthentication;
using iTrip.Service.Business.Relation.IRelationRecipient;
using iTrip.Service.Business.Relation.RelationRecipient;
using iTrip.Service.Common.Wcf;
using iTrip.Service.Wcf.Relation.ITripperRelationShipResolver;

namespace iTrip.Service.Wcf.Relation.TripperRelationShipResolver
{
    [WinWcfService]
    public class RecipientRegistration : SuperWcfService, IRecipientRegistration
    {
        public void RegisterTripper(string account, string ticket)
        {
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(ticket)) return;
            IRelationAccountRegistration registration = new RelationAccountRegistration();
            registration.Register(account, ticket);
        }

        public string RegisterGroup(string master, string name)
        {
            if (string.IsNullOrEmpty(master) || string.IsNullOrEmpty(name)) return null;
            IRelationAccountRegistration registration = new RelationAccountRegistration();
            return registration.RegisterGroup(master, name);
        }

        public string RegisterOrganization(string master, string name)
        {
            if (string.IsNullOrEmpty(master)) return null;
            IRelationAccountRegistration registration = new RelationAccountRegistration();
            return registration.RegisterOrganization(master, name);
        }

        public string RegisterCommunity(string master, string name)
        {
            if (string.IsNullOrEmpty(master)) return null;
            IRelationAccountRegistration registration = new RelationAccountRegistration();
            return registration.RegisterCommunity(master, name);
        }
    }
}
