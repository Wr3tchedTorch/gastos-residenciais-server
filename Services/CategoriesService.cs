using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class CategoriesService : ICategoriesService
    {
        private readonly IRepositoryManager repositoryManager;

        public CategoriesService(IRepositoryManager repositoryManager) 
        { 
            this.repositoryManager = repositoryManager;
        }

        public async Task<Categories> CreateAsync(string description, ExpenseType expenseType, CancellationToken cancellationToken = default)
        {
            Categories category = new()
            {
                Description = description,
                ExpenseType =  expenseType
            };

            repositoryManager.CategoriesRepository.Insert(category);

            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return category;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var category = await repositoryManager.CategoriesRepository.GetByIdAsync(id, cancellationToken);

            repositoryManager.CategoriesRepository.Remove(category);

            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Categories>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await repositoryManager.CategoriesRepository.GetAllAsync(cancellationToken);
        }

        public async Task<Categories> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await repositoryManager.CategoriesRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(int id, string description, CancellationToken cancellationToken = default)
        {
            var category = await repositoryManager.CategoriesRepository.GetByIdAsync(id, cancellationToken);

            category.Description = description;

            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
