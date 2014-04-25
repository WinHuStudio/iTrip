using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using iTrip.Service.Common;
using WinStudio.WcfManager;

namespace iTrip.Web.Controllers
{
    public abstract class iTripController : WebController
    {
        protected JsonResult JResult(bool ret, string msg)
        {
            return Json(new { ret = ret, msg = msg, id = -1 }, "text/html", Encoding.UTF8, JsonRequestBehavior.DenyGet);
        }
        protected JsonResult JResult(bool ret, int id)
        {
            return Json(new { ret = ret, msg = string.Empty, id = id }, "text/html", Encoding.UTF8, JsonRequestBehavior.DenyGet);
        }

        protected JsonResult JResult(StandardResult ret)
        {
            return Json(new { ret = ret.Ret, msg = ret.Msg, id = ret.Num }, "text/html", Encoding.UTF8, JsonRequestBehavior.DenyGet);
        }

        private static string PassportWcfHostAddress;
        private static string RelationWcfHostAddress;
        protected HostInfo WcfHost_Passport
        {
            get
            {
                if (string.IsNullOrEmpty(PassportWcfHostAddress))
                    PassportWcfHostAddress = ConfigurationManager.AppSettings["PassportWcfHostAddress"];
                return new HostInfo(PassportWcfHostAddress);
            }
        }
        protected HostInfo WcfHost_Relation
        {
            get
            {
                if (string.IsNullOrEmpty(RelationWcfHostAddress))
                    RelationWcfHostAddress = ConfigurationManager.AppSettings["RelationWcfHostAddress"];
                return new HostInfo(RelationWcfHostAddress);
            }
        }
    }
}
