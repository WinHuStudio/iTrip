using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using iTrip.Model;
using MongoDB.Repository;

namespace iTrip.Service.DaoRespository
{
    public class RespositoryFactory
    {
        public static IRespository<T> Create<T>() where T : MEntity
        {
            return new Respository<T>();
        }
    }

    public class Respository<T> : SuperRespository<T>, IRespository<T> where T : MEntity
    {
        public virtual void Dispose()
        {
        }
    }


}
