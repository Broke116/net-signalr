using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ShopContext _shopContext;
        private DbSet<T> _dbSet;

        public GenericRepository()
        {
            _shopContext = new ShopContext();
            _dbSet = _shopContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
