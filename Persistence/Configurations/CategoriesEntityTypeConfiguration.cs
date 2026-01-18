using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class CategoriesEntityTypeConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.Property(x => x.ExpenseType)
                    .HasColumnType($"ENUM({string.Join(",", Enum.GetNames<ExpenseType>().Select(x => $"'{x}'"))})")
                    .IsRequired();
        }
    }    
}
