using AnadoluParamApi.Base.Model;
using AnadoluParamApi.Data.Mapping.Concrete;
using AnadoluParamApi.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AnadoluParamApi.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Db Sets
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new SubCategoryMap());
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new OrderDetailMap());
            modelBuilder.ApplyConfiguration(new OrderMap());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }       
    }

    //public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    //{
    //    public AppDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
    //        optionsBuilder.UseSqlServer("server=DESKTOP-JOE5KI8\\SQLEXPRESS02;Database=AnadoluParamApiDB;Trusted_Connection=True; MultipleActiveResultSets=True;");

    //        return new AppDbContext(optionsBuilder.Options);
    //    }
    //}
}
