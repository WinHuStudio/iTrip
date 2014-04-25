using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Core.Security;

namespace iTrip.Web.Common.Security.Validator
{
    public class RequestAuthenticationValidator : IContextValidator
    {
        public int Order
        {
            get { return 6; }
        }
        public WebRequestFilterType FilterType
        {
            get { return WebRequestFilterType.Authentication; }
        }
        public bool Validate(IWebController context)
        {
            if (string.IsNullOrEmpty(context.Account) ||
                string.IsNullOrEmpty(context.DeviceSN) ||
                string.IsNullOrEmpty(context.Ticket))
                return false;
            return TicketGenerator.Instance.ValidTicket(context.Account, context.DeviceSN, context.Ticket);
        }
    }
}
