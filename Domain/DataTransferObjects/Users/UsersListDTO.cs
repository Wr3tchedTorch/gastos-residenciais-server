using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.Users
{
    public class UsersListDTO
    {
        public double TotalExpenses { get; set; } = 0;
        public double TotalIncome   { get; set; } = 0;
        public double TotalBalance  { get; set; } = 0;
        public List<UserDTO> Users { get; set; } = [];
    }
}
