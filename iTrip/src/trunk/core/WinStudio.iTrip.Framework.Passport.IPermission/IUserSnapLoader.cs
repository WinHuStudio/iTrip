using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.iTrip.ICore;
using WinStudio.iTrip.Models;

namespace WinStudio.iTrip.Framework.Passport.IPermission
{
    public interface IUserSnapLoader
    {
        IUserSnap Load(string securityToken, LoginType type);

        void SetResource(string resource);
    }

}
