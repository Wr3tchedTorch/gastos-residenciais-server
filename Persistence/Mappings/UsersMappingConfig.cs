using Domain.DataTransferObjects.Transactions;
using Domain.DataTransferObjects.Users;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mappings
{
    internal class UsersMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig<Users, UserDTO>.NewConfig().PreserveReference(true);

            TypeAdapterConfig<Users, UserDTO>.NewConfig()
                .Ignore(dest => dest.TotalExpenses)
                .Ignore(dest => dest.TotalIncome)
                .Ignore(dest => dest.TotalBalance)
                .Ignore(dest => dest.Transactions);
        }
    }
}
