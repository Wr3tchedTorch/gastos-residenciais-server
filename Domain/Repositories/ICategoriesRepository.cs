using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICategoriesRepository
    {
        public Task<List<Categories>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<Categories> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public void Insert(Categories newUser);
        public void Remove(Categories user);
    }
}
