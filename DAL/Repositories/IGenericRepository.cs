using System;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
