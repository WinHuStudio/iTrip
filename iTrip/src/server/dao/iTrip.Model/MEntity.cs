using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace iTrip.Model
{
    public class MEntity : Entity
    {
        //public DaoModelResult Result(bool result, string msg)
        //{
        //    return new DaoModelResult() { Result = result, Msg = msg };
        //}
        //public DaoModelResult Result(string msg)
        //{
        //    return new DaoModelResult() { Result = false, Msg = msg };
        //}
        //public DaoModelResult Result()
        //{
        //    return new DaoModelResult() { Result = true };
        //}

        public virtual bool IsValid() { return false; }

        public override void Save()
        {
            throw new Exception("Can not use this method to save one entity in itrip");
        }
        public override void Remove()
        {
            throw new Exception("Can not use this method to remove one entity in itrip");
        }
    }
}
