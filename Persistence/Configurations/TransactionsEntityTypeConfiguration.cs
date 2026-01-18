using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    internal class TransactionsEntityTypeConfiguration : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {            
            builder.Property(x => x.ExpenseType)
                .HasColumnType($"ENUM({string.Join(",", Enum.GetNames<UniqueExpenseType>().Select(x => $"'{x}'"))})")
                .IsRequired();
        }
    }
}
