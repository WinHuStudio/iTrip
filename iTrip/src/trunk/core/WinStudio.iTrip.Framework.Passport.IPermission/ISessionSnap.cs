using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.iTrip.ICore;

namespace WinStudio.iTrip.Framework.Passport.IPermission
{
    public interface ISessionSnap
    {
        IUserSnap UserSnap { get; set; }

        DateTime LastTime { get; set; }

        string SecurityToken { get; }

        bool IsValidUser(IUserSnap snap);
    }
}
