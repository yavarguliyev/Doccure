using Core.Enum;
using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IUserService
    {
        Task<User> GetAsync(int id);
        Task<User> GetByTokenAsync(string token);
        Task<User> GetByInviteTokenAsync(string token);
        Task<User> GetByConfirmTokenAsync(string token);
        Task<User> GetBySlugAsync(string slug);
        Task<User> GetByCodeAsync(string code);
        Task<User> GetByEmailAsync(string email);
        Task<bool> CheckEmailAsync(string email);

        Task<User> UpdateAsync(int id, string token);
        Task<User> LoginAsync(string email, string password);
        Task<User> CreateAsync(User newUser, UserRole role);
        Task<User> UpdateAsync(User userToBeUpdated, User user);
    }
}