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
        public async Task<Patient> GetAsync(int id)
        {
            return await _unitOfWork.Patient.Get(id);
        }
        #endregion

        #region create, update and delete
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

        public async Task<Patient> UpdateAsync(Patient patientToBeUpdated, Patient patient)
        {
            patientToBeUpdated.Id = patientToBeUpdated.Id;
            patientToBeUpdated.Status = true;
            patientToBeUpdated.AddedDate = patientToBeUpdated.AddedDate;
            patientToBeUpdated.ModifiedDate = DateTime.Now;
            patientToBeUpdated.AddedBy = patientToBeUpdated.AddedBy;
            patientToBeUpdated.ModifiedBy = patientToBeUpdated.ModifiedBy;

            patientToBeUpdated.Type = patient.Type != 0 ? patient.Type : patientToBeUpdated.Type;

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return patientToBeUpdated;
            throw new Exception("Problem saving changes");
        }

        public async Task DeleteAsync(Patient patient)
        {
            _unitOfWork.Patient.Remove(patient);
            await _unitOfWork.CommitAsync();
        }
        #endregion
    }
}