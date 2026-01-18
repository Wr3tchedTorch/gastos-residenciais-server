using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.Users
{
    public class UserSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public uint Age { get; set; }
    }
}
