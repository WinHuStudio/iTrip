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

    public abstract class SuperRespository<T> where T : MEntity
    {
        public virtual bool Exists(string id)
        {
            return MongoEntity.Exists<T>(id);
        }
        public virtual bool Exists(Expression<Func<T, bool>> where)
        {
            return MongoEntity.Exists<T>(where);
        }

        public virtual T Get(string id)
        {
            return MongoEntity.Get<T>(id);
        }
        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return MongoEntity.Get<T>(where);
        }
        public virtual IQueryable<T> Select(Expression<Func<T, bool>> where)
        {
            return MongoEntity.Select<T>(where);
        }
        public virtual IQueryable<T> Select(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, int pageIndex, int pageSize, out int pageCount, out int allCount)
        {
            return MongoEntity.Select<T>(where, orderby, pageIndex, pageSize, out pageCount, out allCount);
        }

        public virtual void Save(T entity)
        {
            MongoEntity.Save<T>(entity);
        }
        public virtual void Save(List<T> entities)
        {
            MongoEntity.Save<T>(entities);
        }

        public virtual void Delete(string id)
        {
            MongoEntity.Remove<T>(id);
        }
        public virtual void Delete(T t)
        {
            t.Remove();
        }

        public virtual long Count(Expression<Func<T, bool>> where)
        {
            return MongoEntity.Count<T>(where);
        }
        public virtual void Insert(List<T> entities)
        {
            MongoEntity.InsertBatch<T>(entities);
        }
    }
}
