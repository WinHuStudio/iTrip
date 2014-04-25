using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Core.Security;

namespace iTrip.Web.Common.Security.Validator
{
    public class RequestTicketValidator : IContextValidator
    {

        public int Order
        {
            get { return 2; }
        }
        public WebRequestFilterType FilterType
        {
            get { return WebRequestFilterType.Ticket; }
        }

        public bool Validate(IWebController context)
        {
            return !string.IsNullOrEmpty(context.Ticket);
        }

    }
}
