using System.Linq.Expressions;

namespace iGlycemic.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        bool Any(Expression<Func<T, bool>> filter = null);
        IQueryable<T> Query(Expression<Func<T, bool>> filter = null);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
