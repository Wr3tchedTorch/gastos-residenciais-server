using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence
{
    public sealed class ExpensesManagementDatabaseContext(DbContextOptions<ExpensesManagementDatabaseContext> options) : DbContext(options)
    {
        public DbContextOptions<ExpensesManagementDatabaseContext> Options { get; } = options;

        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpensesManagementDatabaseContext).Assembly);
        }
    }
}
