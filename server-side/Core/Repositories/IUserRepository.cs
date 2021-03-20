using Core.Enum;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> Get(UserRole role, int? id);
        Task<User> Get(int id);
        Task<User> Get(string token);
        Task<User> GetBy(string queryValue);
        Task<bool> CheckEmail(string email);
    }
}