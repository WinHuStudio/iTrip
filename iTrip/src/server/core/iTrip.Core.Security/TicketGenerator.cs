using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Core.Security
{
    public class TicketGenerator
    {
        private static ITicketGenerator _instance = new iTripperTicketGenerator();
        public static ITicketGenerator Instance
        {
            get
            {
                return _instance;
            }
        }

        public static void SetTicketGenerator(ITicketGenerator generator)
        {
            _instance = generator;
        }

    }


}
