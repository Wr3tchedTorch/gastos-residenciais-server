using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ICategoriesService
    {
        public Task<List<Categories>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<Categories> CreateAsync(string description, ExpenseType expenseType, CancellationToken cancellationToken = default);
        public Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
