using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinStudio.iTrip.Dto.Passport;
using WinStudio.iTrip.Framework.Passport.Permission;
using WinStudio.iTrip.Permission.IPassport;

namespace WinStudio.iTrip.Passport.Controllers
{
    [NeedAuthorized]
    public class ProfileController : iTripPassportController
    {
        //
        // GET: /Profile/

        public ActionResult Index()
        {
            var ibsProfile = GetService<IProfile>();
            var ret = ibsProfile.GetProfile(Me.Id);
            if (!ret.Ret)
                return View(new Profile());
            return View(ret.Instance<Profile>());
        }

    }
}
