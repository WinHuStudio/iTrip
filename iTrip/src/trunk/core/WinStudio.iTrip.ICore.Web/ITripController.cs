using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WinStudio.ComResult;

namespace System.Web.Mvc
{
    public interface ITripController : IController
    {
        T GetService<T>(string account);
        ComRet Result();
        ComRet Result(bool ret, string msg = null);
        ComRet Result(string err);
        ComRet Result(object obj);
        ComRet Result(int num);
        ComRet Result(bool ret, string msg, int num, object obj);
        ActionResult RedirectToLocal(string url = null);

        void Log(string message);
        void Log(Exception e);
        void Log(string format, object arg0);
        void Log(string format, object arg0, object arg1);
        void Log(string format, object arg0, object arg1, object arg2);
        void Log(string format, object[] args);
    }
}
