using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IChatRepository : IRepository<Chat>
    {
        Task<IEnumerable<Chat>> Get(int id);
        Task<Chat> Get(int id, int userId);
    }
}