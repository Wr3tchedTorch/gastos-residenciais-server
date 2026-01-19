using Domain.DataTransferObjects.Users;
using Domain.Entities;

namespace Services.Abstractions
{
    public interface IUsersService
    {
        public Task<UsersListDTO> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<UserDTO> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<Users> CreateAsync(string name, uint age, CancellationToken cancellationToken = default);
        public Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        public Task UpdateAsync(int id, string? newName, uint? newAge, CancellationToken cancellationToken = default);
    }
}
