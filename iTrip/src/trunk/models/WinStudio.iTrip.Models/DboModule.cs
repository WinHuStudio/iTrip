using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;
using WinStudio.DynamicLogger;

namespace WinStudio.iTrip.Models
{
    public abstract class DboModule<T> : IDboModel<T> where T : iTripBaseEntity
    {
        protected T Tdto;
        public void InitDto(string id)
        {
            Tdto = MongoEntity.Get<T>(id);
        }

        public bool IsDtoReady
        {
            get { return Tdto != null; }
        }

        public void Log(string msg)
        {
            DLogger.GetLogger<T>(Tdto.LoggerCode).Info(msg);
        }

        public void Log(Exception e)
        {
            DLogger.GetLogger<T>(Tdto.LoggerCode).Info(e);
        }

        public void Log(string formater, object[] args)
        {
            DLogger.GetLogger<T>(Tdto.LoggerCode).InfoFormat(formater, args);
        }
    }
}
