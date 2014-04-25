using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.WcfManager;

namespace iTrip.Service.Common
{
    public abstract class SuperWcfService : SuperStandardResultService
    {
        protected HostInfo GetWcfHostInfo(string code = null, bool ishttp = true)
        {
            var addr = ConfigurationManager.AppSettings[code ?? DefWcfAddress];
            if (string.IsNullOrEmpty(addr))
                return null;
            return new HostInfo(addr, ishttp);
        }

        protected T GetService<T>(string wcfaddr, bool ishttp = true)
        {
            return GetWcfHostInfo(wcfaddr, ishttp).GetService<T>();

        }
        protected T GetService<T>()
        {
            return GetService<T>(DefWcfAddress, DefWcfIsHttp);

        }

        public virtual string DefWcfAddress { get { return "DefWcfAddress"; } }
        public virtual bool DefWcfIsHttp { get { return true; } }
    }
}
