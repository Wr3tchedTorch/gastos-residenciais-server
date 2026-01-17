using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Users : IdentityUser
    {
        public string Name { get; set; } = null!;
        public uint Age { get; set; }
    }
}
