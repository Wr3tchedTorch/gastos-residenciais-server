using Domain.DataTransferObjects.Transactions;
using Domain.DataTransferObjects.Users;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
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
        public async Task<UsersListDTO> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var users = await repositoryManager.UsersRepository.GetAllAsync(cancellationToken);

            UsersListDTO usersListDto = new();

            usersListDto.Users = [.. users
                    .Select(user =>
                    {
                        UserDTO userDto = new();

                        user.Adapt(userDto);
                        userDto.Transactions = user.Transactions.Adapt<List<TransactionSummaryDTO>>();

                        userDto = CalculateBalanceInformation(userDto);

                        usersListDto.TotalExpenses += userDto.TotalExpenses;
                        usersListDto.TotalIncome   += userDto.TotalIncome;
                        usersListDto.TotalBalance  += userDto.TotalBalance;

                        return userDto;
                    })];

            usersListDto.TotalBalance = usersListDto.TotalIncome - usersListDto.TotalExpenses;

            return usersListDto;
        }

        public async Task<UserDTO> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var user = await repositoryManager.UsersRepository.GetByIdAsync(id, cancellationToken);

            UserDTO userDto = user.Adapt<UserDTO>();

            CalculateBalanceInformation(userDto);

            userDto.TotalBalance = userDto.TotalIncome - userDto.TotalExpenses;

            return userDto;
        }

        public async Task<Users> CreateAsync(string name, uint age, CancellationToken cancellationToken = default)
        {            
            Users user = new()
            {
                Name = name,
                Age = age,
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

        private void CalculateBalanceInformation(UserDTO user, UsersListDTO usersListDto)
        {
            CalculateBalanceInformation(user);

            usersListDto.TotalExpenses += user.TotalExpenses;
            usersListDto.TotalIncome  +=  user.TotalIncome;
        }

        private UserDTO CalculateBalanceInformation(UserDTO user)
        {
            if (user.Transactions == null || user.Transactions.Count == 0)
            {
                user.TotalExpenses = 0;
                user.TotalIncome = 0;

                return user;
            }

            user.TotalExpenses = user.Transactions
                .Where(t => t.ExpenseType == Domain.Enums.UniqueExpenseType.Despesa)
                .Sum(t => t.Value);

            user.TotalIncome = user.Transactions
                .Where(t => t.ExpenseType == Domain.Enums.UniqueExpenseType.Receita)
                .Sum(t => t.Value);

            return user;
        }
    }
}
