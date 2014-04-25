using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.DeliveryCenter;
using iTrip.Push.iTripSession;
using SuperSocket.SocketBase;
using SuperWebSocket;

namespace iTrip.Push.ServerManager
{
    public class TripAppServer : WebSocketServer<TripSession>
    {
        public TripAppServer()
        {

        }

        public void RegisterEvents()
        {
            //this.NewMessageReceived += new SessionHandler<TripSession, string>(socketServer_NewMessageReceived);
            this.NewSessionConnected += socketServer_NewSessionConnected;
            this.SessionClosed += socketServer_SessionClosed;
        }

        public void PushPackage(string sender, string[] receivers, Content package)
        {
        }

        #region ws Events

        void socketServer_NewSessionConnected(TripSession session)
        {
            session.Send("hello, welcome to itrip!".ToBase64String());
        }
        void socketServer_SessionClosed(TripSession session, CloseReason reason)
        {
            session.Send("see you!".ToBase64String());
        }
        void socketServer_NewMessageReceived(TripSession session, string e)
        {
            session.Send("you have a new message: " + e);
        }
        #endregion
    }
}
