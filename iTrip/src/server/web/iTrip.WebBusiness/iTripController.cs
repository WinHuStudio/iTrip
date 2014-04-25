using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using iTrip.Service.Common;

namespace iTrip.WebBusiness
{
    public abstract class iTripController : Controller
    {
        //bool CheckRequest() {
        //    if (HttpContext.Request.HttpMethod == "POST") return false;
        //    if(!HttpContext.Request.Headers.AllKeys.Contains("iTripping.cn"))
        //}

        //string CheckVersion()
        //{
        //    string version = HttpContext.Request.Headers[iTrippingVersion];
        //}

        //public ComRet Result() { return new ComRet(); }
        //public ComRet Result(bool ret, string msg = null) { return new ComRet(ret, msg); }
        //public ComRet Result(string err) { return new ComRet(err); }
        //public ComRet Result(object obj) { return new ComRet(obj); }
        //public ComRet Result(int num) { return new ComRet(num); }
        //public ComRet Result(bool ret, string msg, int num, object obj) { return new ComRet(ret, msg, num, obj); }

        public JsonResult JResult(WcfResult ret)
        {
            return Json(new { ret = ret.Ret, msg = ret.StrValue, id = ret.IntValue }, "text/xml", Encoding.UTF8, JsonRequestBehavior.DenyGet);
        }
        public JsonResult JResult(bool ret, string msg)
        {
            return Json(new { ret = ret, msg = msg, id = -1 }, "text/xml", Encoding.UTF8, JsonRequestBehavior.DenyGet);
        }
        public JsonResult JResult(bool ret, int id)
        {
            return Json(new { ret = ret, msg = string.Empty, id = id }, "text/xml", Encoding.UTF8, JsonRequestBehavior.DenyGet);
        }
    }
}
