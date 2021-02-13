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

        #region get patient
        public Task<Patient> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region create and update
        public async Task<Patient> CreateAsync(Patient newPatient)
        {
            newPatient.Status = true;
            newPatient.AddedDate = DateTime.Now;
            newPatient.ModifiedDate = DateTime.Now;
            newPatient.AddedBy = "System";
            newPatient.ModifiedBy = "System";

            await _unitOfWork.Patient.AddAsync(newPatient);

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return newPatient;

            throw new Exception("Problem saving changes");
        }

        public Task UpdateAsync(Patient patientToBeUpdated, Patient patient)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}