using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStudio.iTrip.Dto.Passport
{
    public class LoginHistory : UIBaseEntity
    {
        public LoginHistory()
            : this(string.Empty, string.Empty)
        { }
        public LoginHistory(string account, string origin)
        {
            Account = account;
            Origin = origin;
            Time = DateTime.Now;
        }

        public string Account { get; set; }

        public string Origin { get; set; }

        public DateTime Time { get; set; }
    }
}
