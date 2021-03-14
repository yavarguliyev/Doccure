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
        private readonly IDoctorSocialMediaUrlLinkService _urlLink;

        public DoctorService(IUnitOfWork unitOfWork, 
                             IDoctorSocialMediaUrlLinkService urlLink)
        {
            _unitOfWork = unitOfWork;
            _urlLink = urlLink;
        }

        #region get doctor
        public async Task<Doctor> GetAsync(int id)
        {
            return await _unitOfWork.Doctor.Get(id);
        }
        #endregion

        #region create, update and delete
        public async Task<int> CreateAsync(Doctor newDoctor)
        {
            newDoctor.Status = true;
            newDoctor.AddedDate = DateTime.Now;
            newDoctor.ModifiedDate = DateTime.Now;
            newDoctor.AddedBy = "System";
            newDoctor.ModifiedBy = "System";

            await _unitOfWork.Doctor.AddAsync(newDoctor);

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success)
            {
                var socialUrl = new DoctorSocialMediaUrlLink
                {
                    DoctorId = newDoctor.Id
                };

                await _urlLink.CreateAsync(socialUrl);

                return newDoctor.Id;
            }

            throw new Exception("Problem saving changes");
        }

        public async Task<Doctor> UpdateAsync(Doctor doctorToBeUpdated, Doctor doctor)
        {
            doctorToBeUpdated.Id = doctorToBeUpdated.Id;
            doctorToBeUpdated.Status = true;
            doctorToBeUpdated.AddedDate = doctorToBeUpdated.AddedDate;
            doctorToBeUpdated.ModifiedDate = DateTime.Now;
            doctorToBeUpdated.AddedBy = doctorToBeUpdated.AddedBy;
            doctorToBeUpdated.ModifiedBy = doctorToBeUpdated.ModifiedBy;

            doctorToBeUpdated.Type = doctor.Type != 0 ? doctor.Type : doctorToBeUpdated.Type;
            doctorToBeUpdated.Position = doctor.Position != 0 ? doctor.Position : doctorToBeUpdated.Position;

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return doctorToBeUpdated;
            throw new Exception("Problem saving changes");
        }

        public async Task DeleteAsync(Doctor doctor)
        {
            var url = await _urlLink.GetAsync(doctor.Id);
            await _urlLink.DeleteAsync(url);

            _unitOfWork.Doctor.Remove(doctor);
            await _unitOfWork.CommitAsync();
        }
        #endregion
    }
}