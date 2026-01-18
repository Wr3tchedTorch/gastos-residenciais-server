using Domain.DataTransferObjects.Transactions;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mappings
{
    internal class TransactionsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig<TransactionForUpdateDTO, Transactions>.NewConfig().IgnoreNullValues(true);
        }
    }
}
