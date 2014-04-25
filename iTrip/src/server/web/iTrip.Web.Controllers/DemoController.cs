using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace iTrip.Web.Controllers
{
    public class DemoController : iTripController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
