using Domain.Entities;
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
