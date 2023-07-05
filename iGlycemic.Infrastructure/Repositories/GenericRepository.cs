using iGlycemic.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace iGlycemic.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal DbContextClass _dbContext;
        internal DbSet<T> _dbSet;

        protected GenericRepository(DbContextClass context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();

        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }
        public bool Any(Expression<Func<T, bool>> filter = null)
        {
            bool any = false;

            IQueryable<T> query = _dbSet;

            if (filter != null)
                any = query.Any<T>(filter);

            return any;
        }
        public IQueryable<T> Query(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = _dbSet.Where<T>(filter);

            return query;
        }
    }
}
