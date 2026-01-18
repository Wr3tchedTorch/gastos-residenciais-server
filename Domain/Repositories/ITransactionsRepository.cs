using Domain.DataTransferObjects.Transactions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITransactionsRepository
    {
        public Task<List<TransactionDTO>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<TransactionDTO> GetDtoByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<Transactions> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public void Insert(Transactions newTransaction);
        public void Remove(Transactions transaction);
    }
}
