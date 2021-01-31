using Core;
using Core.Models;
using Core.Services.Data;
using System;
using System.Threading.Tasks;

namespace Services.Data
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Admin> GetAsync(int id)
        {
            return await _unitOfWork.Admin.Get(id);
        }

        public Task UpdateAsync(int id, string token)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Admin adminToBeUpdated, Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}