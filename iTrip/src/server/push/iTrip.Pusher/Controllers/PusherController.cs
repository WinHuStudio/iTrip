using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTrip.Push.ServerManager;

namespace iTrip.Pusher.Controllers
{
    public class PusherController : Controller
    {
        //
        // GET: /Pusher/

        public ActionResult Index()
        {
            ViewBag.AllAppServerNames = AppFactory.GetAllAppServerNames();
            return View();
        }

        public ActionResult Demo()
        {
            return View();
        }

    }
}
