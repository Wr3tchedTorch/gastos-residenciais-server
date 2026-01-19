using Domain.DataTransferObjects.Categories;
using Domain.DataTransferObjects.Transactions;
using Domain.DataTransferObjects.Users;
using Domain.Entities;
using Domain.Exceptions.Transactions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class TransactionsRepository : ITransactionsRepository
    {
        private readonly ExpensesManagementDatabaseContext dbContext;

        public TransactionsRepository(ExpensesManagementDatabaseContext dbContext) 
        { 
            this.dbContext = dbContext;
        }

        public async Task<List<TransactionDTO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.Transactions
                .Select(TransactionDTOMappings.ToDto)
                .ToListAsync(cancellationToken);
        }

        public async Task<TransactionDTO> GetDtoByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var transaction = await dbContext.Transactions
                .Where(x => x.Id == id)
                .Select(TransactionDTOMappings.ToDto)
                .FirstOrDefaultAsync(cancellationToken)
            ?? throw new TransactionNotFoundException(id);

            return transaction;
        }

        public async Task<Transactions> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var transaction = await dbContext.Transactions
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken)
            ?? throw new TransactionNotFoundException(id);

            return transaction;
        }

        public void Insert(Transactions newTransaction)
        {
            dbContext.Transactions.Add(newTransaction);
        }

        public void Remove(Transactions transaction)
        {
            dbContext.Transactions.Remove(transaction);
        }
    }
}
