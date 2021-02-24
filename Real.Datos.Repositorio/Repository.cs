using Real.Dominio.RepositorioInterfaces;
using Release.Helper.Data.ICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Real.Datos.Repositorio
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IContext _context;

        public Repository(IContext context)
        {
            _context = context;
        }

        protected IContext DataContext
        {
            get { return _context; }
        }

        public virtual T Add(T entity)
        {
            return _context.Add(entity);
        }

        public virtual void Add(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _context.Add(entity);
            }
        }

        public virtual T Find(params object[] keys)
        {
            return _context.Find<T>(keys);
        }

        public virtual T GetById(long id)
        {
            return _context.GetById<T>(id);
        }

        public T GetById(int id)
        {
            return _context.GetById<T>(id);
        }

        public virtual T GetById(string id)
        {
            return _context.GetById<T>(id);
        }

        public virtual IQueryable<T> Query(bool asNoTracking = true)
        {
            return _context.Query<T>(asNoTracking);
        }

        public virtual void Remove(T entity)
        {
            _context.Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Update(T entity, params Expression<Func<T, object>>[] properties)
        {
            _context.Update(entity, properties);
        }
    }
}
