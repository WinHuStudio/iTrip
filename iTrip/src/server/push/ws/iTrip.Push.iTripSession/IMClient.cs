using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.IProxy;
using WinStudio.Msmq.Client;

namespace iTrip.Push.iTripSession
{
    public class IMClient : ClientInfo<iPP.Proxy.ipp_Package>
    {
        public IMClient(string name) : base(name) { }

    }

    public class ClientFactory
    {
        private static string _server = ".";
        public static void SetMsmqServer(string server)
        {
            _server = server;
        }

        public static IMClient CreateClient(string name)
        {
            IMClient client = new IMClient(name);
            client.RegisterClient(_server);
            return client;
        }
    }
}
