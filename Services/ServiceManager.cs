using Domain.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUsersService> lazyUsersService;
        private readonly Lazy<ICategoriesService> lazyCategoriesService;
        private readonly Lazy<ITransactionsService> lazyTransactionsService;

        public ServiceManager(IRepositoryManager repositoryManager) 
        {
            lazyUsersService = new Lazy<IUsersService>(() => new UsersService(repositoryManager));
            lazyCategoriesService = new Lazy<ICategoriesService>(() => new CategoriesService(repositoryManager));
            lazyTransactionsService = new Lazy<ITransactionsService>(() => new TransactionsService(repositoryManager));
        }

        public IUsersService UsersService => lazyUsersService.Value;
        public ICategoriesService CategoriesService => lazyCategoriesService.Value;
        public ITransactionsService TransactionsService => lazyTransactionsService.Value;
    }
}
