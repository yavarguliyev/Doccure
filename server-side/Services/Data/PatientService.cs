using Core;
using Core.Models;
using Core.Services.Data;
using System;
using System.Threading.Tasks;

namespace Services.Data
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Patient> CreateAsync(Patient newPatient)
        {
            newPatient.Status = true;
            newPatient.AddedDate = DateTime.Now;
            newPatient.ModifiedDate = DateTime.Now;
            newPatient.AddedBy = "System";
            newPatient.ModifiedBy = "System";

            await _unitOfWork.Patient.AddAsync(newPatient);
            await _unitOfWork.CommitAsync();

            return newPatient;
        }

        public Task<Patient> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, string token)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Patient patientToBeUpdated, Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}