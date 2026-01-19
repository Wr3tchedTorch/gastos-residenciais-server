using Domain.DataTransferObjects.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.Users
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public uint Age { get; set; }
        public List<TransactionSummaryDTO> Transactions { get; set; } = null!;
        public double TotalExpenses { get; set; }
        public double TotalIncome { get; set; }
        public double TotalBalance { get; set; }
    }
}
