using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using iTrip.Model;

namespace iTrip.Service.DaoRespository
{
    public interface IRespository<T> : IDisposable where T : MEntity
    {
        bool Exists(string id);
        bool Exists(Expression<Func<T, bool>> where);
        T Get(string id);
        T Get(Expression<Func<T, bool>> where);

        IQueryable<T> Select(Expression<Func<T, bool>> where);
        IQueryable<T> Select(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, int pageIndex, int pageSize, out int pageCount, out int allCount);

        void Save(T entity); void Save(List<T> entities);
        void Delete(string id);
        void Delete(T t);
        long Count(Expression<Func<T, bool>> where);
        void Insert(List<T> entities);
    }
}
