using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.Categories
{
    public class CategoryForCreationDTO
    {
        public string Description { get; set; } = null!;
        public ExpenseType ExpenseType { get; set; }
    }
}
