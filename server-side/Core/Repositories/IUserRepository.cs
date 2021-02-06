using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Get(int id);
        Task<User> GetByToken(string token);
        Task<User> GetByInviteToken(string token);
        Task<User> GetByConfirmToken(string token);
        Task<User> GetBySlug(string slug);
        Task<User> GetByEmail(string email);
        Task<bool> CheckEmail(string email);
    }
}