using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Core.Security;

namespace iTrip.Web.Common.Security.Validator
{
    public class RequestDeviceTypeValidator : IContextValidator
    {
        public int Order
        {
            get { return 5; }
        }
        public WebRequestFilterType FilterType
        {
            get { return WebRequestFilterType.DeviceType; }
        }

        public bool Validate(IWebController context)
        {
            return context.DeviceType != DeviceType.Unknown;
        }
    }
}
