using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Push.iTripSession;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using SuperWebSocket;

namespace iTrip.Push.ServerManager
{
    public class AppFactory
    {
        private static IDictionary<string, TripAppServer> apps = new Dictionary<string, TripAppServer>();

        public static void SetAppServer(string appServerName)
        {
            if (apps.ContainsKey(appServerName))
                return;

            IBootstrap m_Bootstrap = BootstrapFactory.CreateBootstrap();

            if (!m_Bootstrap.Initialize())
                return;

            TripAppServer socketServer = m_Bootstrap.AppServers.FirstOrDefault(s => s.Name.Equals(appServerName)) as TripAppServer;
            socketServer.RegisterEvents();

            m_Bootstrap.Start();
            apps.Add(appServerName, socketServer);
        }
        public static TripAppServer GetAppServer(string appServerName)
        {
            return apps[appServerName];
        }

        public static List<string> GetAllAppServerNames()
        {
            return apps.Keys.ToList();
        }

        //public static List<string> DispatchPackage(JsonChatMessage
    }
}
