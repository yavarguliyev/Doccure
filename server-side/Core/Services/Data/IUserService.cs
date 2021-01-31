using Core.Enum;
using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IUserService
    {
        Task<User> GetAsync(int id);
        Task<User> GetAsync(string token);
        Task<User> GetBySlugAsync(string slug);
        Task<User> GetByCodeAsync(string code);
        Task<bool> CheckEmailAsync(string email);
        Task<User> LoginAsync(string email, string password);
        Task<User> CreateAsync(User newUser, UserRole role);
        Task UpdateAsync(int id, string token);
        Task UpdateAsync(User userToBeUpdated, User user);
    }
}