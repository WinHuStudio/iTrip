using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WinStudio.iTrip.Framework.Passport.Permission;
using WinStudio.iTrip.Location.Business;
using WinStudio.iTrip.Location.IBusiness;

namespace WinStudio.iTrip.Web.Areas.Map.Controllers
{
    [NeedAuthorized]
    [NeedLocation]
    public class TrippingController : iTripWebController
    {
        //
        // GET: /Map/Tripping/

        public ActionResult Index()
        {
            LocationCollector.Instance.UpdateLocation(Me.Account, NeedLocationAttribute.Longitude, NeedLocationAttribute.Latitude);
            NeedLocationAttribute.Longitude += NeedLocationAttribute.Interval;
            NeedLocationAttribute.Latitude += NeedLocationAttribute.Interval;
            return View();
        }


        public void GetTrippingCompanionLocations()
        {

            StringBuilder sb = new StringBuilder();
            var snaps = LocationCollector.Instance.GetLocations(1, 10);
            snaps.ForEach(delegate(ISnapLocation snap)
            {
                if (sb.Length > 0) sb.Append(",");
                sb.Append(snap.ToString());
            });


            HttpContext.Response.ContentType = "text/event-stream";
            HttpContext.Response.CacheControl = "no-cache";
            HttpContext.Response.Write("data:{" + string.Format("\"count\":{0},\"snaps\":\"{1}\"", snaps.Count, sb.ToString()) + "}\n\n");
            HttpContext.Response.Flush();
        }
    }
}
