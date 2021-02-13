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
        public async Task<Doctor> GetAsync(int id)
        {
            return await _unitOfWork.Doctor.Get(id);
        }
        #endregion

        #region create, update and delete
        public async Task<Doctor> CreateAsync(Doctor newDoctor)
        {
            newDoctor.Status = true;
            newDoctor.AddedDate = DateTime.Now;
            newDoctor.ModifiedDate = DateTime.Now;
            newDoctor.AddedBy = "System";
            newDoctor.ModifiedBy = "System";

            await _unitOfWork.Doctor.AddAsync(newDoctor);

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return newDoctor;

            throw new Exception("Problem saving changes");
        }

        public Task UpdateAsync(Doctor doctorToBeUpdated, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Doctor doctor)
        {
            _unitOfWork.Doctor.Remove(doctor);
            await _unitOfWork.CommitAsync();
        }
        #endregion
    }
}