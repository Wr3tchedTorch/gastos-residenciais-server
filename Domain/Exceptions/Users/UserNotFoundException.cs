using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Users
{
    public class UserNotFoundException(int id) : NotFoundException($"User with id `{id}` not found in the database.")
    {
    }
}
