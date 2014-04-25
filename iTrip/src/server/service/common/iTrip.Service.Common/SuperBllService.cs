using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Model;
using iTrip.Service.DaoRespository;

namespace iTrip.Service.Common
{
    public abstract class SuperBllService : SuperStandardResultService
    {
        protected IRespository<T> GetRespository<T>() where T : MEntity
        {
            return RespositoryFactory.Create<T>();
        }
    }

    public abstract class SuperBllService<T> : SuperBllService where T : MEntity
    {
    }
}
