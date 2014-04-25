using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Web.Common.Security.Validator
{
    public class RequestVersionValidator : IContextValidator
    {
        public int Order
        {
            get { return 1; }
        }
        public WebRequestFilterType FilterType
        {
            get { return WebRequestFilterType.Version; }
        }
        public bool Validate(IWebController context)
        {
            if (string.IsNullOrEmpty(context.ClientVersion)) return false;
            return Versions.Contains(context.ClientVersion);
        }


        private List<string> _versioins = new List<string>();
        private List<string> Versions
        {
            get
            {
                if (_versioins.Count == 0)
                {
                    var versions = ConfigurationManager.AppSettings[GlobalConst.CodeInRequest_iTripClientVersion];
                    _versioins.AddRange(versions.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
                }
                return _versioins;
            }
        }


    }
}
