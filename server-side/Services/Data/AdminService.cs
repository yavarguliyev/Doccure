using System.Security.AccessControl;
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
        public async Task<Admin> UpdateAsync(Admin adminToBeUpdated, Admin admin)
        {
            adminToBeUpdated.Id = adminToBeUpdated.Id;
            adminToBeUpdated.Status = true;
            adminToBeUpdated.AddedDate = adminToBeUpdated.AddedDate;
            adminToBeUpdated.ModifiedDate = DateTime.Now;
            adminToBeUpdated.AddedBy = adminToBeUpdated.AddedBy;
            adminToBeUpdated.ModifiedBy = adminToBeUpdated.ModifiedBy;

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return adminToBeUpdated;
            throw new Exception("Problem saving changes");
        }
        #endregion
    }
}