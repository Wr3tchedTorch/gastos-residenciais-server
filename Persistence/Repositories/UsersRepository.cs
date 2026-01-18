using Microsoft.EntityFrameworkCore;
using Domain.Exceptions.Users;
using Domain.Repositories;
using Domain.Entities;

namespace Persistence.Repositories
{
    internal class UsersRepository : IUsersRepository
    {
        private readonly ExpensesManagementDatabaseContext context;

        public UsersRepository(ExpensesManagementDatabaseContext context) 
        { 
            this.context = context;
        }

        public async Task<List<Users>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var users = await context.Users.ToListAsync(cancellationToken: cancellationToken);

            return users;
        }

        public async Task<Users> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var user = await context.Users.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken: cancellationToken)
                ?? throw new UserNotFoundException(id);

            return user;
        }

        public void Insert(Users newUser)
        {
            context.Users.Add(newUser);
        }

        public void Remove(Users user)
        {
            context.Users.Remove(user);
        }
    }
}
