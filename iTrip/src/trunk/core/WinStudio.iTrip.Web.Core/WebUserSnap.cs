using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.iTrip.Core;
using WinStudio.iTrip.ICore;

namespace WinStudio.iTrip.Web.Core
{
    [Serializable]
    public class WebUserSanp : UserSnap
    {
        public string SecurityKey { get; set; }

        public string Id { get; set; }

        public string Account { get; set; }

        public string Name { get; set; }

        //public static IUserSnap Default
        //{
        //    get
        //    {
        //        return new WebUserSanp()
        //        {
        //            SecurityKey = "---UnloginedSecurityKey---",
        //            Id = "---UnloginedId---",
        //            Account = "---UnloginedAccount---",
        //            Name = "---UnloginedUser---"
        //        };
        //    }
        //}
    }
}
