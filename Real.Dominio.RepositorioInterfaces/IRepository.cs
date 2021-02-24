using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Real.Dominio.RepositorioInterfaces
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);

        void Add(IEnumerable<T> entities);

        T Find(params object[] keys);

        T GetById(long id);

        T GetById(int id);

        T GetById(string id);

        IQueryable<T> Query(bool asNoTracking = true);

        void Remove(T entity);

        void Update(T entity);

        void Update(T entity, params Expression<Func<T, object>>[] properties);
    }
}
