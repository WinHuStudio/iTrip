using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.DynamicLogger;

namespace WinStudio.iTrip.Models
{
    public interface ITripDLogger
    {
        void Log(string message);
        void Log(Exception e);
        void Log(string format, object[] args);
    }

    public abstract class TripDLogger : ITripDLogger
    {
        private Type _type;
        private string _code;
        public TripDLogger(Type type, string code)
        {
            _type = type;
            _code = code;
        }

        public void Log(string message)
        {
            DLogger.GetLogger(_type, _code).Info(message);
        }

        public void Log(Exception e)
        {
            DLogger.GetLogger(_type, _code).Info(e);
        }

        public void Log(string format, object[] args)
        {
            DLogger.GetLogger(_type, _code).InfoFormat(format, args);
        }
    }
}
