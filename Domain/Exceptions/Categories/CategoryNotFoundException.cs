using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Categories
{
    public class CategoryNotFoundException(int id) : NotFoundException($"Category with id `{id}` not found in the database.")
    {
    }
}
