using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categories
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public ExpenseType ExpenseType { get; set; }

        public List<Transactions> Transactions { get; set; } = null!;
    }
}
