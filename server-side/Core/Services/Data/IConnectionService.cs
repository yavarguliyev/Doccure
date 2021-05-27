using Core.Models.Hubs;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IConnectionService
    {
        Task<Connection> GetConnectionAsync(string connectionId);
        Task DeleteAsync(Connection connection);
    }
}