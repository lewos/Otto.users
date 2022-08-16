using Otto.users.DTOs;

namespace Otto.users.Repositories
{
    public interface IUsersRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task<User> GetUserByMailPassAsync(string mail, string pass);
        Task<User> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(string id, User user);
        Task<bool> DeleteUserAsync(string id);
        Task<User> GetByMUserIdAsync(string id);
        Task<User> GetByTUserIdAsync(string id);
    }
}
