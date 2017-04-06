using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ShopContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ShopContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext can't be null.");

            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        //protected ShopContext DbContext
        //{
        //    get { return _shopContext ?? ( _shopContext = new ShopContext()); }
        //}

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
