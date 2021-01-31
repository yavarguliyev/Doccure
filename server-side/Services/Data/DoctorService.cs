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

        public Task<Doctor> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

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

        public Task UpdateAsync(int id, string token)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Doctor doctorToBeUpdated, Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}