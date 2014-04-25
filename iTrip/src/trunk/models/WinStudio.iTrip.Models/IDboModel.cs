using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStudio.iTrip.Models
{
    public interface IDboModel<T> where T : iTripBaseEntity
    {
        void InitDto(string id);
        bool IsDtoReady { get; }

        void Log(string msg);
        void Log(Exception e);
        void Log(string formater, object[] args);
    }
}
