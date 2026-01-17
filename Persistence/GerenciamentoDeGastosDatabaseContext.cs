using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence
{
    public sealed class GerenciamentoDeGastosDatabaseContext(DbContextOptions<GerenciamentoDeGastosDatabaseContext> options) : IdentityDbContext<Users>(options)
    {
        public DbContextOptions<GerenciamentoDeGastosDatabaseContext> Options { get; } = options;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GerenciamentoDeGastosDatabaseContext).Assembly);
        }
    }
}
