using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Persistence.Configurations
{
    internal class CategoriesEntityTypeConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder
                    .HasMany(e => e.Transactions)
                    .WithOne(e => e.Category)
                    .HasForeignKey(e => e.CategoryId)
                    .HasPrincipalKey(e => e.Id);

            builder.Property(x => x.ExpenseType)
                    .HasColumnType($"ENUM({string.Join(",", Enum.GetNames<ExpenseType>().Select(x => $"'{x}'"))})")
                    .IsRequired();
        }
    }    
}
