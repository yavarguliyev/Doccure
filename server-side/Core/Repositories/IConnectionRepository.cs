using Core.Models.Hubs;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IConnectionRepository : IRepository<Connection>
    {
        Task<Connection> GetConnection(string connectionId);
    }
}