using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Service.Wcf.Passport.IAuthentication;

namespace iTrip.TestConsoler.Wcf
{
    public class WcfPassport : WcfBase
    {
        public void Register()
        {
            Console.WriteLine("input account");
            string acc = Console.ReadLine();
            Console.WriteLine("input password");
            string pwd = Console.ReadLine();

            var passport = GetService<IServiceAuthenticationReception>();
            var ret = passport.Register(acc, pwd.ToMD5());

            Console.WriteLine("注册结果{0}，Ticket={1}", ret.Ret, ret.Msg);
        }
    }
}
