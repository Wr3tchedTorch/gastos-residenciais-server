using Domain.DataTransferObjects.Categories;
using Domain.DataTransferObjects.Users;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.Transactions
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public double Value { get; set; }
        public UniqueExpenseType ExpenseType { get; set; }
        public CategorySummaryDTO Category { get; set; } = null!;
        public UserSummaryDto User { get; set; } = null!;
    }
}
