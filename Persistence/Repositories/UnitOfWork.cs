using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class UnitOfWork(ExpensesManagementDatabaseContext dbContext) : IUnitOfWork
    {
        private readonly ExpensesManagementDatabaseContext dbContext = dbContext;
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
