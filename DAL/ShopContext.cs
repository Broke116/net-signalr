using DAL.Models;
using System.Data.Entity;

namespace DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("ShopDatabase")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopContext, M>);
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
