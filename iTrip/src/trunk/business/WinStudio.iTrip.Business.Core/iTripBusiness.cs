using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacAutoResolver;
using WinStudio.ComResult;
using WinStudio.DynamicLogger;
using WinStudio.iTrip.Core;
using WinStudio.iTrip.ICore;
using WinStuido.iTrip.Business.ICore;

namespace WinStudio.iTrip.Business.Core
{
    public class iTripBusiness : ITripBusiness
    {
        public ComRet Result() { return new ComRet(); }
        public ComRet Result(bool ret, string msg = null) { return new ComRet(ret, msg); }
        public ComRet Result(string err) { return new ComRet(err); }
        public ComRet Result(object obj) { return new ComRet(obj); }
        public ComRet Result(int num) { return new ComRet(num); }
        public ComRet Result(bool ret, string msg, int num, object obj) { return new ComRet(ret, msg, num, obj); }

        public void SetUserSnap(IUserSnap snap)
        {
            if (_me == null || _me.Account != snap.Account)
                _me = snap;
        }

        public T GetService<T>() where T : ITripBusiness
        {
            return GetService<T>(null);
        }
        public T GetService<T>(IUserSnap me) where T : ITripBusiness
        {
            var ibusiness = AutofacResolver.Instance.GetService<T>();
            ibusiness.SetUserSnap(me);
            return ibusiness;
        }

        private IUserSnap _me;
        protected IUserSnap Me
        {
            get
            {
                return _me;
            }
        }
        protected bool IsLogin { get { return Me != null; } }
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
