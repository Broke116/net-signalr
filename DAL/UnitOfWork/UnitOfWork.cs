using System;
using DAL.Repositories;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _dbContext;

        public UnitOfWork(ShopContext dbContext)
        {
            Database.SetInitializer<ShopContext>(null);

            if (dbContext == null)
                throw new ArgumentNullException("dbContext can't be null.");

            _dbContext = dbContext;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            return new GenericRepository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException err)
            {
                throw err;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
