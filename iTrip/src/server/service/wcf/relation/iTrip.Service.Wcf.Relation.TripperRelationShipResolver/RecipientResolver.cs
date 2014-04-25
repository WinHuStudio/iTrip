using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Service.Business.Relation.IRelationRecipient;
using iTrip.Service.Business.Relation.RelationRecipient;
using iTrip.Service.Common.Wcf;
using iTrip.Service.Wcf.Relation.ITripperRelationShipResolver;

namespace iTrip.Service.Wcf.Relation.TripperRelationShipResolver
{
    [WinWcfService]
    public class RecipientResolver : SuperWcfService, IRecipientResolver
    {
        private IRecipientParser _recipientParser;
        public StandardResult ParseRecipients(string account)
        {
            _recipientParser = new RecipientParser();
            return _recipientParser.ParseRecipient(account);
        }
    }
}
