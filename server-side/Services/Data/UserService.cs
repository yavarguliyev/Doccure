using Core;
using Core.Enum;
using Core.Models;
using Core.Services.Common;
using Core.Services.Data;
using Core.Services.Rest;
using CryptoHelper;
using Data.Errors;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Services.Data
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IActivityService _activityService;
        private readonly IFileManager _fileManager;

        public UserService(IUnitOfWork unitOfWork,
                           IDoctorService doctorService,
                           IPatientService patientService,
                           IActivityService activityService,
                           IFileManager fileManager)
        {
            _unitOfWork = unitOfWork;
            _doctorService = doctorService;
            _patientService = patientService;
            _activityService = activityService;
            _fileManager = fileManager;
        }

        #region get user
        public async Task<IEnumerable<User>> GetAsync(UserRole role)
        {
            return await _unitOfWork.User.Get(role);
        }

        public async Task<User> GetAsync(int id)
        {
            return await _unitOfWork.User.Get(id);
        }

        public async Task<User> GetByTokenAsync(string token)
        {
            return await _unitOfWork.User.GetByToken(token);
        }

        public async Task<User> GetByInviteTokenAsync(string token)
        {
            return await _unitOfWork.User.GetByInviteToken(token);
        }

        public async Task<User> GetByConfirmTokenAsync(string token)
        {
            return await _unitOfWork.User.GetByConfirmToken(token);
        }

        public async Task<User> GetBySlugAsync(string slug)
        {
            return await _unitOfWork.User.GetBySlug(slug);
        }

        public async Task<User> GetByCodeAsync(string code)
        {
            return await _unitOfWork.User.SingleOrDefaultAsync(x => x.Code == code);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _unitOfWork.User.GetByEmail(email);
        }

        public async Task<bool> CheckEmailAsync(string email)
        {
            return await _unitOfWork.User.CheckEmail(email);
        }
        #endregion

        #region create and update
        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _unitOfWork.User.SingleOrDefaultAsync(x => x.Email == email);
            if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
            {
                if (user != null && user.Token != null)
                {
                    var loggedInUser = await this.UpdateAsync(user.Id, Guid.NewGuid().ToString());

                    return loggedInUser;
                }
            }

            throw new RestException(HttpStatusCode.Unauthorized, new { user = "Invalid email or password" });
        }

        public async Task<User> CreateAsync(User newUser, UserRole role)
        {
            await this.CheckEmailAsync(newUser.Email);

            switch (role)
            {
                case UserRole.Doctor:
                    var newDoctor = new Doctor();
                    var doctor = await _doctorService.CreateAsync(newDoctor);
                    newUser.DoctorId = doctor.Id;
                    break;
                case UserRole.Patient:
                    var newPatient = new Patient();
                    var patient = await _patientService.CreateAsync(newPatient);
                    newUser.PatientId = patient.Id;
                    break;
                default:
                    break;
            }

            var random = new Random();
            var code = random.Next(100000, 999999).ToString();
            while (await this.GetByCodeAsync(code) != null)
            {
                code = random.Next(100000, 999999).ToString();
            }

            newUser.Status = true;
            newUser.AddedDate = DateTime.Now;
            newUser.ModifiedDate = DateTime.Now;
            newUser.AddedBy = "System";
            newUser.ModifiedBy = "System";
            newUser.Code = code;
            newUser.Photo = null;
            newUser.Birth = newUser.Birth.Year != 0001 ? newUser.Birth : DateTime.Now;
            newUser.Fullname = newUser.Fullname != null ? newUser.Fullname : null;
            newUser.Slug = newUser.Fullname != null ? newUser.Fullname.Replace(" ", "-").ToLower() : null;
            newUser.Password = newUser.Password != null ? Crypto.HashPassword(newUser.Password) : null;
            newUser.Token = newUser.Token != null ? newUser.Token : null;
            newUser.InviteToken = newUser.InviteToken != null ? newUser.InviteToken : null;
            newUser.ConfirmToken = newUser.ConfirmToken != null ? newUser.ConfirmToken : null;
            newUser.AdminId = null;
            newUser.Role = role;

            await _unitOfWork.User.AddAsync(newUser);

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success)
            {
                var url = string.Empty;

                if (newUser.ConfirmToken != null)
                {
                    switch (newUser.Role)
                    {
                        case UserRole.Doctor:
                            url = $"/doctors/auth/confirm-email?token={newUser.ConfirmToken}";
                            break;
                        case UserRole.Patient:
                            url = $"/patients/auth/confirm-email?token={newUser.ConfirmToken}";
                            break;
                        default:
                            throw new RestException(HttpStatusCode.BadRequest, new { user = "Make sure you have valid role for resseting your account." });
                    }

                    await _activityService.SendEmail(newUser, "Complete register process", "Register account",
                          "To complete register process please fill out all the neessary inputs!", true,
                          "Complete register process", url);
                }

                return newUser;
            }
            else
            {
                throw new Exception("Problem saving changes");
            }
        }

        public async Task<User> UpdateAsync(int id, string token)
        {
            var user = await _unitOfWork.User.SingleOrDefaultAsync(x => x.Id == id);
            user.Token = Guid.NewGuid().ToString();

            await _unitOfWork.CommitAsync();

            return user;
        }

        public async Task<User> UpdateAsync(User userToBeUpdated, User user)
        {
            userToBeUpdated.Id = userToBeUpdated.Id;
            userToBeUpdated.Status = true;
            userToBeUpdated.AddedDate = userToBeUpdated.AddedDate;
            userToBeUpdated.ModifiedDate = DateTime.Now;
            userToBeUpdated.AddedBy = userToBeUpdated.AddedBy;
            userToBeUpdated.ModifiedBy = userToBeUpdated.ModifiedBy;

            userToBeUpdated.Code = userToBeUpdated.Code;
            userToBeUpdated.Photo = user.Photo != null ? user.Photo : userToBeUpdated.Photo;

            switch (user.Gender)
            {
                case Gender.Male:
                    userToBeUpdated.Gender = Gender.Male;
                    break;
                case Gender.Female:
                    userToBeUpdated.Gender = Gender.Female;
                    break;
                default:
                    userToBeUpdated.Gender = userToBeUpdated.Gender;
                    break;
            }

            switch (user.Role)
            {
                case UserRole.Admin:
                    userToBeUpdated.Role = UserRole.Admin;
                    break;
                case UserRole.Doctor:
                    userToBeUpdated.Role = UserRole.Doctor;
                    break;
                case UserRole.Patient:
                    userToBeUpdated.Role = UserRole.Patient;
                    break;
                default:
                    userToBeUpdated.Role = userToBeUpdated.Role;
                    break;
            }

            userToBeUpdated.Password = userToBeUpdated.Password;

            userToBeUpdated.Token = user.Token != null ? user.Token : Guid.NewGuid().ToString();
            userToBeUpdated.InviteToken = user.InviteToken != null ? user.InviteToken : null;
            userToBeUpdated.ConfirmToken = user.ConfirmToken != null ? user.ConfirmToken : null;
            userToBeUpdated.ConnectionId = user.ConnectionId != null ? user.ConnectionId : null;

            userToBeUpdated.Fullname = user.Fullname != null ? user.Fullname : userToBeUpdated.Fullname;
            userToBeUpdated.Slug = user.Slug != null ? user.Fullname.Replace(" ", "-").ToLower() : userToBeUpdated.Slug;
            userToBeUpdated.Email = user.Email != null ? user.Email : userToBeUpdated.Email;
            userToBeUpdated.Birth = user.Birth.Year != 0001 ? user.Birth : userToBeUpdated.Birth;
            userToBeUpdated.AdminId = userToBeUpdated.AdminId;
            userToBeUpdated.DoctorId = userToBeUpdated.DoctorId;
            userToBeUpdated.PatientId = userToBeUpdated.PatientId;

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success)
            {
                if (userToBeUpdated.InviteToken != null)
                {
                    var url = string.Empty;

                    switch (userToBeUpdated.Role)
                    {
                        case UserRole.Doctor:
                            url = $"/doctors/auth/reset-password?token={userToBeUpdated.InviteToken}";
                            break;
                        case UserRole.Patient:
                            url = $"/patients/auth/reset-password?token={userToBeUpdated.InviteToken}";
                            break;
                        default:
                            throw new RestException(HttpStatusCode.BadRequest, new { user = "Make sure you have valid role for resseting your account." });
                    }

                    await _activityService.SendEmail(userToBeUpdated, "Complete reset process",
                          userToBeUpdated.Fullname + "'s password reset",
                          "To complete reset process click to the button!", true,
                          "Complete reset process", url);
                }

                return userToBeUpdated;
            }
            else
            {
                throw new Exception("Problem saving changes");
            }
        }

        public async Task<User> UpdateAsync(int id, string newPassword, string confirmPassword, string currentPassword)
        {
            var user = await this.GetAsync(id);

            if (!string.IsNullOrWhiteSpace(currentPassword))
            {
                if (!Crypto.VerifyHashedPassword(user.Password, currentPassword))
                {
                    throw new RestException(HttpStatusCode.BadRequest, "Current password is not matching");
                }
                else if(currentPassword == newPassword)
                {
                    throw new RestException(HttpStatusCode.BadRequest, "New password cannot match current password!");
                }
            }

            if (newPassword != confirmPassword) throw new RestException(HttpStatusCode.BadRequest, "Confirm Password should match the new password!");
            user.Password = Crypto.HashPassword(newPassword);
            user.InviteToken = null;

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return user;

            throw new Exception("Problem saving changes");
        }

        public async Task StatusAsync(int id)
        {
            var user = await this.GetAsync(id);
            user.Status = !user.Status;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(User user)
        {
            switch (user.Role)
            {
                case UserRole.Doctor:
                    var docotId = user.DoctorId ?? default(int);
                    var doctor = await _doctorService.GetAsync(docotId);
                    _unitOfWork.User.Remove(user);
                    await _doctorService.DeleteAsync(doctor);
                    break;
                case UserRole.Patient:
                    var patientId = user.PatientId ?? default(int);
                    var patient = await _patientService.GetAsync(patientId);
                    _unitOfWork.User.Remove(user);
                    await _patientService.DeleteAsync(patient);
                    break;
                default:
                    break;
            }

            await _unitOfWork.CommitAsync();
        }
        #endregion

        #region photo upload
        public async Task<User> PhotoUpload(int id, IFormFile file)
        {
            var user = await this.GetAsync(id);
            if (user.Photo == null)
            {
                user.Photo = _fileManager.UploadPhoto(file);
            }
            else
            {
                _fileManager.DeletePhoto(user.Photo);
                user.Photo = _fileManager.UploadPhoto(file);
            }

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return user;
            throw new Exception("Problem saving changes");
        }
        #endregion
    }
}