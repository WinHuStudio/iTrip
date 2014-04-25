using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using MongoDB.Repository;

namespace WinStudio.iTrip.Models
{
    public class DboModel<T> : IDboModel<T> where T : iTripBaseEntity
    {
        private T _dto_T;

        private ILog logger;

        public DboModel() { }

        public DboModel(string id)
        {
            _dto_T = MongoEntity.Get<T>(id);
        }
        public DboModel(T dto)
        {
            _dto_T = dto;
        }

        protected T dto_T { get { return _dto_T; } }

        public void InitModel(string id)
        {
            if (IsModelReady) return;
            _dto_T = MongoEntity.Get<T>(id);
        }

        public bool IsModelReady
        {
            get { return _dto_T != null; }
        }

        public void Log(string msg)
        {
            throw new NotImplementedException();
        }

        public void Log(Exception e)
        {
            throw new NotImplementedException();
        }

        public void Log(string formater, object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
