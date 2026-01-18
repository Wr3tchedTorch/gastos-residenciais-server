using Domain.Entities;

namespace Services.Abstractions
{
    public interface IUsersService
    {
        public Task<List<Users>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<Users> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<Users> CreateAsync(string Name, uint Age, CancellationToken cancellationToken = default);
        public Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        public Task UpdateAsync(int id, string? newName, uint? newAge, CancellationToken cancellationToken = default);
    }
}
