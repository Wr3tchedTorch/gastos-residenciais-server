using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Transactions
{
    public class InvalidCategoryException() : ArgumentException($"Category expense type must be compatible with the transaction's expense type.")
    {
    }
}
