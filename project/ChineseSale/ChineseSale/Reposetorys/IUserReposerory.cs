using ChineseSale.Model;

namespace ChineseSale.Repositories
{
    public interface IUserReposerory
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User?> GetByIdUserAsync(int Id);
        public Task<User?> GetByUserNameAsync(string userName);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);

    }
}
