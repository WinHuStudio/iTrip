using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.Encoder;

namespace iTrip.Core.Security
{
    class iTripperTicketGenerator : ITicketGenerator
    {

        public string GenTicket(string account, string devicesn)
        {
            if (string.IsNullOrEmpty(account) ||
                string.IsNullOrEmpty(devicesn))
                throw new NullReferenceException("key can not be null");
            return (account + devicesn).ToAsciiSum().ToHexBEString().ToMD5();
        }

        public bool ValidTicket(string account, string devicesn, string ticket)
        {
            if (string.IsNullOrEmpty(account) ||
                string.IsNullOrEmpty(devicesn) ||
                string.IsNullOrEmpty(ticket)) throw new NullReferenceException("key or ticket can not be null");
            return (account + devicesn).ToAsciiSum().ToHexBEString().ToMD5().Equals(ticket);
        }
    }
}
