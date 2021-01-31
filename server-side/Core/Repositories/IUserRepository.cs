using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Get(int id);
        Task<User> Get(string token);
        Task<User> GetBySlug(string slug);
        Task<bool> CheckEmail(string email);
        Task<User> Login(string email, string password);
    }
}