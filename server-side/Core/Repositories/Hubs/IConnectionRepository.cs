using Core.Models.Hubs;
using Core.Repositories;
using System.Threading.Tasks;

namespace Core.Hubs.Repositories
{
    public interface IConnectionRepository : IRepository<Connection>
    {
        Task<Connection> GetConnection(string email);
    }
}