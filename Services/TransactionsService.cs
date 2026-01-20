using Domain.DataTransferObjects.Transactions;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions.Transactions;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public async Task<TransactionDTO> CreateAsync(TransactionForCreationDTO body, CancellationToken cancellationToken = default)
        {
            await CheckValidCategory(body.CategoryId, body.ExpenseType, cancellationToken);

            Transactions newTransaction = new();

            body.Adapt(newTransaction);

            repositoryManager.TransactionsRepository.Insert(newTransaction);

            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return await GetByIdAsync(newTransaction.Id, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var transaction = await repositoryManager.TransactionsRepository.GetByIdAsync(id, cancellationToken);

            repositoryManager.TransactionsRepository.Remove(transaction);

            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<TransactionDTO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await repositoryManager.TransactionsRepository.GetAllAsync(cancellationToken);
        }

        public async Task<TransactionDTO> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await repositoryManager.TransactionsRepository.GetDtoByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(int id, TransactionForUpdateDTO body, CancellationToken cancellationToken = default)
        {
            var transaction = await repositoryManager.TransactionsRepository.GetByIdAsync(id, cancellationToken);

            UniqueExpenseType? expenseTypeForCheck = body.ExpenseType;
            if (body.CategoryId.HasValue && !body.ExpenseType.HasValue)
            {
                expenseTypeForCheck = transaction.ExpenseType;
            }

            int? categoryIdForCheck = body.CategoryId;
            if (!body.CategoryId.HasValue && body.ExpenseType.HasValue)
            {
                categoryIdForCheck = transaction.CategoryId;
            }

            if (categoryIdForCheck.HasValue && expenseTypeForCheck.HasValue)
            {
                await CheckValidCategory(categoryIdForCheck.Value, expenseTypeForCheck.Value, cancellationToken);
            }

            body.Adapt(transaction);

            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        private async Task CheckValidCategory(int categoryId, UniqueExpenseType expenseType, CancellationToken cancellationToken)
        {
            var category = await repositoryManager.CategoriesRepository.GetByIdAsync(categoryId, cancellationToken);

            if (category.ExpenseType == ExpenseType.Ambas)
            {
                return;
            }

            if ((int) category.ExpenseType != (int) expenseType)
            {
                throw new InvalidCategoryException();
            }
        }
    }
}
