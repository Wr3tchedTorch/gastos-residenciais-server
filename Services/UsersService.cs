using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    internal class UsersService : IUsersService
    {
        private readonly IRepositoryManager repositoryManager;

        public UsersService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }
        public async Task<List<Users>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await repositoryManager.UsersRepository.GetAllAsync(cancellationToken);
        }

        public async Task<Users> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await repositoryManager.UsersRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<Users> CreateAsync(string Name, uint Age, CancellationToken cancellationToken = default)
        {            
            Users user = new()
            {
                Name = Name,
                Age = Age,
            };

            repositoryManager.UsersRepository.Insert(user);

            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return user;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            Users user = await repositoryManager.UsersRepository.GetByIdAsync(id, cancellationToken);

            repositoryManager.UsersRepository.Remove(user);

            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(int id, string? newName, uint? newAge, CancellationToken cancellationToken = default)
        {
            Users user = await repositoryManager.UsersRepository.GetByIdAsync(id, cancellationToken);
            
            if (newName != null)
            {
                user.Name = newName;
            }
            if (newAge != null)
            {
                user.Age = newAge.Value;
            }

            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
