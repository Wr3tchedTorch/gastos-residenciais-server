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
        public Task<List<TransactionDTO>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<TransactionDTO> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<TransactionDTO> CreateAsync(
            TransactionForCreationDTO body,
            CancellationToken cancellationToken = default);
        public Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        public Task UpdateAsync(
            int id,
            TransactionForUpdateDTO body,
            CancellationToken cancellationToken = default);
    }
}
