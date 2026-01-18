using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.Transactions
{
    public class TransactionsForCreationDTO
    {
        public string Description { get; set; } = null!;
        public double Value { get; set; }
        public UniqueExpenseType ExpenseType { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
