using Domain.Entities;
using Domain.Exceptions.Categories;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class CategoriesRepository : ICategoriesRepository
    {
        private readonly ExpensesManagementDatabaseContext dbContext;

        public CategoriesRepository(ExpensesManagementDatabaseContext dbContext) 
        { 
            this.dbContext = dbContext;
        }

        public async Task<List<Categories>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var categories = await dbContext.Categories.ToListAsync(cancellationToken);

            return categories;
        }

        public async Task<Categories> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var category = await dbContext.Categories.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken: cancellationToken)
                ?? throw new CategoryNotFoundException(id);

            return category;
        }

        public void Insert(Categories newUser)
        {
            dbContext.Categories.Add(newUser);
        }

        public void Remove(Categories user)
        {
            dbContext.Categories.Remove(user);
        }
    }
}
