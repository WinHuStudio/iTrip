using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperWebSocket.SubProtocol;

namespace iTrip.Push.Commands
{
    public class iTripCommandAttribute : SubCommandFilterAttribute
    {
        public override void OnCommandExecuted(SuperSocket.SocketBase.CommandExecutingContext commandContext)
        {
            throw new NotImplementedException();
        }

        public override void OnCommandExecuting(SuperSocket.SocketBase.CommandExecutingContext commandContext)
        {
            throw new NotImplementedException();
        }
    }
}
