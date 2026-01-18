using Domain.DataTransferObjects.Transactions;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ITransactionsService
    {
        public Task<List<Transactions>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<Transactions> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<Transactions> CreateAsync(
            TransactionsForCreationDTO body,
            CancellationToken cancellationToken = default);
        public Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        public Task UpdateAsync(
            int id,
            TransactionsForUpdateDTO body,
            CancellationToken cancellationToken = default);
    }
}
