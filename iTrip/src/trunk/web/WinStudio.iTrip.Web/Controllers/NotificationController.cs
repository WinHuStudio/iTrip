using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WinStudio.iTrip.Web.Controllers
{
    public class NotificationController : Controller
    {
        //
        // GET: /Notification/

        public ActionResult Index()
        {
            return View();
        }

        public void Push(string msg)
        {
        }

    }
}
