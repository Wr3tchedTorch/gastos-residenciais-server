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

        public ServiceManager(IRepositoryManager repositoryManager) 
        {
            lazyUsersService = new Lazy<IUsersService>(() => new UsersService(repositoryManager));
        }

        public IUsersService UsersService => lazyUsersService.Value;
    }
}
