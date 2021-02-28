using Microsoft.EntityFrameworkCore;
using OTC.Domain.Models;

namespace OTC.Infrastructure
{
    public class DbMainContext : DbContext
    {
        public DbMainContext(DbContextOptions<DbMainContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasMany(d => d.Employees);
            modelBuilder.Entity<Employee>().HasOne(e => e.Department);

            base.OnModelCreating(modelBuilder);
        }
    }
}
