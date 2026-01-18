using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Transactions
{
    public class TransactionNotFoundException(int id) : NotFoundException($"Transaction with id `{id}` not found in the database.")
    {
    }
}
