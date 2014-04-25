using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AutofacAutoResolver;
using WinStudio.iTrip.Framework.Passport.IPermission;
using WinStudio.iTrip.ICore;
using WinStudio.iTrip.Models;
using WinStudio.iTrip.Permission.IPassport;
using WinStudio.iTrip.Permission.PassportService;

namespace WinStudio.iTrip.Web.Core.Permission
{
    public class PassportUserSnapLoader : IUserSnapLoader
    {
        private string _resource;

        public IUserSnap Load(string securityToken, LoginType type)
        {
            var _ibsprofile = AutofacResolver.Instance.GetService<IProfile>();
            return _ibsprofile.GetUserSnap(securityToken, type);
        }

        public void SetResource(string resource)
        {
            _resource = resource;
        }
    }
}
