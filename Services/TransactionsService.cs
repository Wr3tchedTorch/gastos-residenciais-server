using Domain.DataTransferObjects.Transactions;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class TransactionsService : ITransactionsService
    {
        private readonly IRepositoryManager repositoryManager;

        public TransactionsService(IRepositoryManager repositoryManager) 
        { 
            this.repositoryManager = repositoryManager;
        }

        public async Task<Transactions> CreateAsync(TransactionsForCreationDTO body, CancellationToken cancellationToken = default)
        {
            Transactions newTransaction = new();

            body.Adapt(newTransaction);

            repositoryManager.TransactionsRepository.Insert(newTransaction);

            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return newTransaction;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var transaction = await repositoryManager.TransactionsRepository.GetByIdAsync(id, cancellationToken);

            repositoryManager.TransactionsRepository.Remove(transaction);

            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Transactions>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await repositoryManager.TransactionsRepository.GetAllAsync(cancellationToken);
        }

        public async Task<Transactions> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await repositoryManager.TransactionsRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(int id, TransactionsForUpdateDTO body, CancellationToken cancellationToken = default)
        {
            var transaction = await repositoryManager.TransactionsRepository.GetByIdAsync(id, cancellationToken);

            body.Adapt(transaction);

            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
