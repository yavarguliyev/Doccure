using Core;
using Core.Models.Hubs;
using Core.Services.Data;
using System.Threading.Tasks;

namespace Services.Data
{
    public class ConnectionService : IConnectionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConnectionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Connection> GetConnectionAsync(string connectionId)
        {
            return await _unitOfWork.Connection.GetConnection(connectionId);
        }

        public async Task DeleteAsync(Connection connection)
        {
            _unitOfWork.Connection.Remove(connection);
            await _unitOfWork.CommitAsync();
        }
    }
}