using Core;
using Core.Models;
using Core.Services.Data;
using System;
using System.Threading.Tasks;

namespace Services.Data
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region get doctor
        public Task<Doctor> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region create and update
        public async Task<Doctor> CreateAsync(Doctor newDoctor)
        {
            newDoctor.Status = true;
            newDoctor.AddedDate = DateTime.Now;
            newDoctor.ModifiedDate = DateTime.Now;
            newDoctor.AddedBy = "System";
            newDoctor.ModifiedBy = "System";

            await _unitOfWork.Doctor.AddAsync(newDoctor);
            await _unitOfWork.CommitAsync();

            return newDoctor;
        }

        public Task UpdateAsync(Doctor doctorToBeUpdated, Doctor doctor)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}