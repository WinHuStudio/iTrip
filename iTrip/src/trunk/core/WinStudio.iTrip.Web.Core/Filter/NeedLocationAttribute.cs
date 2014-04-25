using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public class NeedLocationAttribute : ActionFilterAttribute
    {
        public static double Longitude = 39.92;
        public static double Latitude = 116.46;
        public static double Interval = 0.01;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);


            //var user = WinWebGlobalManager.Guider.GetUserInfo(filterContext.RequestContext.HttpContext);
            //var snap = filterContext.RequestContext.HttpContext.GetFromSession<SnapLocation>();
            //if (snap == null)
            //{
            //    snap = new SnapLocation(user.Account, user.Name, Longitude, Latitude, 1, 10);
            //    filterContext.RequestContext.HttpContext.SaveToSession(snap.Account, snap);
            //    LocationCollector.Instance.GatherLocation(user.Account,user.Name,Longitude,Latitude,1,10);
            //}
            //else
            //{
            //    LocationCollector.Instance.UpdateLocation(user.Account, new LocationLonLat(Longitude, Latitude));
            //    Longitude += Interval;
            //    Latitude += Interval;
            //}


        }

    }
}
