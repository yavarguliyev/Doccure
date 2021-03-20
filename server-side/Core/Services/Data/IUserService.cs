using Core.DTOs.Auth;
using Core.Enum;
using Core.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAsync(UserRole role, int? id);
        Task<User> GetAsync(int id);
        Task<User> GetAsync(string token);
        Task<User> GetByAsync(string queryValue);
        Task<User> GetByCodeAsync(string code);
        Task<bool> CheckEmailAsync(string email);

        Task<UserDTO> LoginAsync(string email, string password);
        Task CreateAsync(User newUser, UserRole role);
        Task<UserDTO> UpdateAsync(User userToBeUpdated, User user);
        Task<UserDTO> UpdateAsync(int id, string newPassword, string confirmPassword, string currentPassword);
        Task StatusAsync(int id);
        Task DeleteAsync(User user);

        Task<UserDTO> TokenAsync(int id, string token);
        Task<UserDTO> InviteTokenAsync(User user);
        Task<UserDTO> ConfirmTokenAsync(string token);

        Task<string> PhotoUploadAsync(int id, IFormFile file);
    }
}