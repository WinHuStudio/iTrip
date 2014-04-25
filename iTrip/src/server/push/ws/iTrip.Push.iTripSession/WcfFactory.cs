using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.WcfManager;

namespace iTrip.Push.iTripSession
{
    public class WcfFactory
    {
        private static HostInfo _host;
        public static HostInfo PackageDeliveryHost
        {
            get
            {
                if (_host == null)
                    _host = new HostInfo(ConfigurationManager.AppSettings["PackageDeliveryWcfHostAddress"]);
                return _host;
            }
        }
    }
}
