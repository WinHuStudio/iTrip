using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Core.Security;

namespace iTrip.Web.Common.Security.Validator
{
    public class RequestDeviceSNValidator : IContextValidator
    {
        public int Order
        {
            get { return 4; }
        }
        public WebRequestFilterType FilterType
        {
            get { return WebRequestFilterType.DeviceSN; }
        }

        public bool Validate(IWebController context)
        {
            return !string.IsNullOrEmpty(context.DeviceSN);
        }
    }
}
