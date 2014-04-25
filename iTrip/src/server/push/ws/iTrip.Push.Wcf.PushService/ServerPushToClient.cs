using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.Proxy;
using iTrip.Push.iTripSession;
using iTrip.Push.ServerManager;

namespace iTrip.Push.Wcf.PushService
{
    public class ServerPushToClient : IServerPushToClient
    {
        public void PushPackage(ipp_Package[] package, string receiver)
        {
            AppFactory.GetAppServer("iTripIMPushServer").GetSessions(s => s.Account == receiver).ToList().ForEach(
                delegate(TripSession session)
                {
                    package.ForEach(delegate(ipp_Package pk)
                    {
                        byte[] bytes = pk.ToClientBytes();
                        session.Send(bytes, 0, bytes.Length);
                    });
                });
        }
    }
}
