using Domain.DataTransferObjects.Categories;
using Domain.DataTransferObjects.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.Transactions
{
    public static class TransactionDTOMappings
    {
        public static Expression<Func<Domain.Entities.Transactions, TransactionDTO>> ToDto => t => new TransactionDTO
        {
            Id = t.Id,
            Description = t.Description,
            Value = t.Value,
            ExpenseType = t.ExpenseType,
            User = new UserSummaryDto 
            { 
                Id = t.UserId,
                Name = t.User.Name, 
                Age = t.User.Age 
            },
            Category = new CategorySummaryDTO
            {
                Id = t.CategoryId,
                Description = t.Category.Description,
                ExpenseType = t.Category.ExpenseType
            }
        };
    }
}
