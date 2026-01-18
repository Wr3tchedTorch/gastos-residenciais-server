using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class RepositoryManager(ExpensesManagementDatabaseContext dbContext) : IRepositoryManager
    {
        private readonly Lazy<IUsersRepository> lazyUsersRepository = new(() => new UsersRepository(dbContext));
        private readonly Lazy<IUnitOfWork> lazyUnitOfWork = new(() => new UnitOfWork(dbContext));
        private readonly Lazy<ICategoriesRepository> lazyCategoriesRepository = new(() => new CategoriesRepository(dbContext));

        public IUsersRepository UsersRepository => lazyUsersRepository.Value;
        public IUnitOfWork UnitOfWork => lazyUnitOfWork.Value;
        public ICategoriesRepository CategoriesRepository => lazyCategoriesRepository.Value;
    }
}
