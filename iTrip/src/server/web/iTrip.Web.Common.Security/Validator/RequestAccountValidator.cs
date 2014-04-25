using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Core.Security;

namespace iTrip.Web.Common.Security.Validator
{
    public class RequestAccountValidator : IContextValidator
    {
        public int Order
        {
            get { return 3; }
        }
        public WebRequestFilterType FilterType
        {
            get { return WebRequestFilterType.Account; }
        }

        public bool Validate(IWebController context)
        {
            return !string.IsNullOrEmpty(context.Account);
        }
    }
}
