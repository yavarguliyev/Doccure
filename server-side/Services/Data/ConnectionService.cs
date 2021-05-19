using Core;
using Core.Services.Data;

namespace Services.Data
{
    public class ConnectionService : IConnectionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConnectionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}