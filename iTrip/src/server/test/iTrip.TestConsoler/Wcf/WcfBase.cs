using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.WcfManager;

namespace iTrip.TestConsoler.Wcf
{
    public abstract class WcfBase
    {
        private static HostInfo _host = new HostInfo(ConfigurationManager.AppSettings["WcfHostAddress"]);
        protected T GetService<T>()
        {
            return _host.GetService<T>();
        }
    }
}
