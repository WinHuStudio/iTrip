using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.ComResult;
using WinStudio.iTrip.ICore;

namespace WinStuido.iTrip.Business.ICore
{
    public interface ITripBusiness
    {
        void SetUserSnap(IUserSnap snap);

        T GetService<T>(IUserSnap me) where T : ITripBusiness;
        T GetService<T>() where T : ITripBusiness;
        ComRet Result();
        ComRet Result(bool ret, string msg = null);
        ComRet Result(string err);
        ComRet Result(object obj);
        ComRet Result(int num);
        ComRet Result(bool ret, string msg, int num, object obj);

        void Log(string message);
        void Log(Exception e);
        void Log(string format, object arg0);
        void Log(string format, object arg0, object arg1);
        void Log(string format, object arg0, object arg1, object arg2);
        void Log(string format, object[] args);
    }
}
