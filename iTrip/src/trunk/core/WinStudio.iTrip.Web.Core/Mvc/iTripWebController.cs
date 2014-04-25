using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutofacAutoResolver;
using WinStudio.ComResult;
using WinStudio.DynamicLogger;
using WinStudio.iTrip.Framework.Passport.Permission;
using WinStudio.iTrip.ICore;
using WinStudio.iTrip.Models;
using WinStuido.iTrip.Business.ICore;

namespace System.Web.Mvc
{
    public abstract class iTripWebController : Controller, ITripWebController
    {
        protected string IP
        {
            get
            {
                return HttpContext.GetIP();
            }
        }

        public IUserSnap Me
        {
            get
            {
                return Reception.Instance.GetUser(HttpContext.GetToken(WebConfiguration.Instance.ConfigSecurityTokenName), LoginType.Web);
            }
        }

        public bool IsLogin { get { return null != Me; } }

        public T GetService<T>() where T : ITripBusiness
        {
            var ibusiness = AutofacResolver.Instance.GetService<T>();
            ibusiness.SetUserSnap(Me);
            return ibusiness;
        }
        public ComRet Result() { return new ComRet(); }
        public ComRet Result(bool ret, string msg = null) { return new ComRet(ret, msg); }
        public ComRet Result(string err) { return new ComRet(err); }
        public ComRet Result(object obj) { return new ComRet(obj); }
        public ComRet Result(int num) { return new ComRet(num); }
        public ComRet Result(bool ret, string msg, int num, object obj) { return new ComRet(ret, msg, num, obj); }

        public ActionResult RedirectToLocal(string url = null)
        {
            if (string.IsNullOrEmpty(url))
                return RedirectToAction("Index", "Home");
            else return Redirect(url);
        }

        private const string AnonymousUserDLogCode = "---Anonymous---";
        public void Log(string message)
        {
            if (IsLogin)
                DLogger.GetLogger<IUserSnap>(Me.Account).Info(message);
            else DLogger.GetLogger<IUserSnap>(AnonymousUserDLogCode).Info(message);
        }

        public void Log(Exception e)
        {
            if (IsLogin)
                DLogger.GetLogger<IUserSnap>(Me.Account).Info(e);
            else DLogger.GetLogger<IUserSnap>(AnonymousUserDLogCode).Info(e);
        }

        public void Log(string format, object arg0)
        {
            if (IsLogin)
                DLogger.GetLogger<IUserSnap>(Me.Account).InfoFormat(format, arg0);
            else DLogger.GetLogger<IUserSnap>(AnonymousUserDLogCode).InfoFormat(format, arg0);
        }

        public void Log(string format, object arg0, object arg1)
        {
            if (IsLogin)
                DLogger.GetLogger<IUserSnap>(Me.Account).InfoFormat(format, arg0, arg1);
            else DLogger.GetLogger<IUserSnap>(AnonymousUserDLogCode).InfoFormat(format, arg0, arg1);
        }

        public void Log(string format, object arg0, object arg1, object arg2)
        {
            if (IsLogin)
                DLogger.GetLogger<IUserSnap>(Me.Account).InfoFormat(format, arg0, arg1, arg2);
            else DLogger.GetLogger<IUserSnap>(AnonymousUserDLogCode).InfoFormat(format, arg0, arg1, arg2);
        }

        public void Log(string format, object[] args)
        {
            if (IsLogin)
                DLogger.GetLogger<IUserSnap>(Me.Account).InfoFormat(format, args);
            else DLogger.GetLogger<IUserSnap>(AnonymousUserDLogCode).InfoFormat(format, args);
        }
    }
}
