using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStudio.iTrip.Framework.Passport.IPermission
{
    public interface IUserPermissionLoader
    {
        void Load(string account, string securityToken);

        void SetResource(string resource);
    }
}
