using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Push.iTripSession;
using SuperWebSocket.SubProtocol;

namespace iTrip.Push.Commands
{
    public abstract class iTripCommandBase : SubCommandBase<TripSession>
    {
        public override void ExecuteCommand(TripSession session, SubRequestInfo requestInfo)
        {
            session.ExcuteRequestPackage(requestInfo);
        }
    }
}
