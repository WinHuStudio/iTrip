using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Core.Security;

namespace iTrip.Web.Common.Security.Validator
{
    public class RequestWebMethodValidator : IContextValidator
    {
        private string _method = "POST";
        public RequestWebMethodValidator(string method = "POST")
        {
            _method = method;
        }

        public int Order
        {
            get { return 0; }
        }
        public WebRequestFilterType FilterType
        {
            get { return WebRequestFilterType.WebMethod; }
        }

        public bool Validate(IWebController context)
        {
            return context.WebMethod.Equals(_method);
        }
    }
}
