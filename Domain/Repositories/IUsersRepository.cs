using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUsersRepository
    {
        public Task<List<Users>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<Users> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public void Insert(Users newUser);
        public void Remove(Users user);
    }
}
