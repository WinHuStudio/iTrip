using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Core.Security
{

    public interface ITicketGenerator
    {
        string GenTicket(string account, string devicesn);
        bool ValidTicket(string account, string devicesn, string ticket);
    }
}
