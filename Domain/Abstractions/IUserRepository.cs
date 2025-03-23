using Domain.Models.UserAggregate;

namespace Domain.Abstractions
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(Guid userId);
        Task<User> GetUserByContactAsync(string email, string phone);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
    }
}
