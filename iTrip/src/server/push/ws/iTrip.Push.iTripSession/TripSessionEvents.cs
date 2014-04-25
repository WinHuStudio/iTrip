using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;

namespace iTrip.Push.iTripSession
{
    public class TripSessionEvents
    {
        public void socketServer_NewSessionConnected(TripSession session)
        {
            session.Send("hello, welcome to itrip!");
        }
        void socketServer_SessionClosed(TripSession session, CloseReason reason)
        {
            session.Send("see you!");
        }
        void socketServer_NewMessageReceived(TripSession session, string e)
        {
            session.Send("you have a new message: " + e);
        }
    }
}
