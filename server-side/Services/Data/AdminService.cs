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

        #region get doctor
        public async Task<Admin> GetAsync(int id)
        {
            return await _unitOfWork.Admin.Get(id);
        }
        #endregion

        #region create and update
        public Task UpdateAsync(Admin adminToBeUpdated, Admin admin)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}