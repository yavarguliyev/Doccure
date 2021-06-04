using AutoMapper;
using Core;
using Core.DTOs.Auth;
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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IActivityService _activityService;
        private readonly IDoctorSocialMediaUrlLinkService _urlLink;
        private readonly ICloudinaryService _cloudinaryService;

        public UserService(IMapper mapper,
                           IUnitOfWork unitOfWork,
                           IDoctorService doctorService,
                           IPatientService patientService,
                           IActivityService activityService,
                           IDoctorSocialMediaUrlLinkService urlLink,
                           ICloudinaryService cloudinaryService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _doctorService = doctorService;
            _patientService = patientService;
            _activityService = activityService;
            _urlLink = urlLink;
            _cloudinaryService = cloudinaryService;
        }

        #region get user
        public async Task<IEnumerable<UserDTO>> GetAsync(UserRole role, int? id)
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _unitOfWork.User.Get(role, id));
        }

        public async Task<User> GetAsync(int id)
        {
            return await _unitOfWork.User.Get(id);
        }

        public async Task<User> GetAsync(string token)
        {
            return await _unitOfWork.User.Get(token);
        }

        public async Task<User> GetByAsync(string queryValue)
        {
            return await _unitOfWork.User.GetBy(queryValue);
        }

        public async Task<User> GetByCodeAsync(string code)
        {
            return await _unitOfWork.User.SingleOrDefaultAsync(x => x.Code == code);
        }

        public async Task<bool> CheckAsync(string queryValue)
        {
            return await _unitOfWork.User.Check(queryValue);
        }
        #endregion

        #region create and update
        public async Task<UserDTO> LoginAsync(string email, string password)
        {
            var user = await this.GetByAsync(email);
            if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
            {
                if (user != null && user.Token != null)
                {
                    var loggedInUser = await this.TokenAsync(user.Id, Guid.NewGuid().ToString());

                    return _mapper.Map<UserDTO>(loggedInUser);
                }
            }

            throw new RestException(HttpStatusCode.Unauthorized, new { user = "Invalid email or password" });
        }

        public async Task CreateAsync(User newUser, UserRole role)
        {
            await this.CheckAsync(newUser.Email);

            newUser.Status = true;
            newUser.AddedDate = DateTime.Now;
            newUser.ModifiedDate = DateTime.Now;
            newUser.AddedBy = "System";
            newUser.ModifiedBy = "System";

            var random = new Random();
            var code = random.Next(100000, 999999).ToString();
            while (await this.GetByCodeAsync(code) != null)
            {
                code = random.Next(100000, 999999).ToString();
            }

            newUser.Code = code;
            newUser.Photo = null;
            newUser.Fullname = newUser.Fullname != null ? newUser.Fullname : null;
            newUser.Slug = newUser.Fullname != null ? newUser.Fullname.Replace(" ", "-").ToLower() : null;

            if (!string.IsNullOrEmpty(newUser.Slug)) await this.CheckAsync(newUser.Slug);

            newUser.Email = newUser.Email != null ? newUser.Email : null;
            newUser.Birth = newUser.Birth.Year != 0001 ? newUser.Birth : DateTime.Now;
            newUser.Phone = newUser.Phone != null ? newUser.Phone : null;
            newUser.Password = newUser.Password != null ? Crypto.HashPassword(newUser.Password) : null;

            newUser.Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                                "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                                "labore et dolore magna aliqua.</div>";
            newUser.PostalCode = "22434";
            newUser.Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>" +
                               "Miami,<br>Florida-33165,<br>United States.</p>";
            newUser.City = "Miami";
            newUser.State = "Florida";
            newUser.Country = "United States";

            switch (role)
            {
                case UserRole.Doctor:
                    var newDoctor = new Doctor();
                    var doctorId = await _doctorService.CreateAsync(newDoctor);
                    newUser.DoctorId = doctorId;
                    break;
                case UserRole.Patient:
                    var newPatient = new Patient();
                    var patientId = await _patientService.CreateAsync(newPatient);
                    newUser.PatientId = patientId;
                    break;
            }

            newUser.Role = role;

            newUser.Token = null;
            newUser.InviteToken = null;
            newUser.ConfirmToken = Guid.NewGuid().ToString();

            newUser.ConnectionId = newUser.ConnectionId != null ? newUser.ConnectionId : null;

            newUser.AdminId = null;

            await _unitOfWork.User.AddAsync(newUser);
            var success = await _unitOfWork.CommitAsync() > 0;
            if (success)
            {
                if (newUser.ConfirmToken != null)
                {
                    var purpose = string.Empty;
                    var title = string.Empty;
                    var body = string.Empty;
                    var btn = false;
                    var url = string.Empty;

                    title = "Registered account";
                    btn = true;

                    switch (newUser.Role)
                    {
                        case UserRole.Doctor:
                            purpose = "Complete register process";
                            body = "To complete register process please fill out all the neessary inputs!";
                            url = $"/auth/doctor-register/{newUser.ConfirmToken}";
                            break;
                        case UserRole.Patient:
                            purpose = "Email confirmation";
                            body = "To confirm your account please click to the button!";
                            url = $"/auth/patient-register/{newUser.ConfirmToken}";
                            break;
                    }

                    await _activityService.SendEmail(newUser, purpose, title, body, btn, url);
                }
            }
            else
            {
                throw new Exception("Problem saving changes");
            }
        }

        public async Task<UserDTO> UpdateAsync(User userToBeUpdated, User user)
        {
            userToBeUpdated.Id = userToBeUpdated.Id;
            userToBeUpdated.Status = true;
            userToBeUpdated.AddedDate = userToBeUpdated.AddedDate;
            userToBeUpdated.ModifiedDate = DateTime.Now;
            userToBeUpdated.AddedBy = userToBeUpdated.AddedBy;
            userToBeUpdated.ModifiedBy = userToBeUpdated.ModifiedBy;

            userToBeUpdated.Code = userToBeUpdated.Code;
            userToBeUpdated.Photo = userToBeUpdated.Photo;

            userToBeUpdated.Fullname = user.Fullname != null ? user.Fullname : userToBeUpdated.Fullname;
            userToBeUpdated.Slug = user.Slug == null ? user.Fullname.Replace(" ", "-").ToLower() : userToBeUpdated.Slug;
            userToBeUpdated.Email = user.Email != null ? user.Email : userToBeUpdated.Email;
            userToBeUpdated.Birth = user.Birth.Year != 0001 ? user.Birth : userToBeUpdated.Birth;
            userToBeUpdated.Phone = user.Phone != null ? user.Phone : userToBeUpdated.Phone;
            userToBeUpdated.Password = user.Password != null ? Crypto.HashPassword(user.Password) : userToBeUpdated.Password;

            userToBeUpdated.Biography = user.Biography != null ? user.Biography : userToBeUpdated.Biography;
            userToBeUpdated.PostalCode = user.PostalCode != null ? user.PostalCode : userToBeUpdated.PostalCode;
            userToBeUpdated.Address = user.Address != null ? user.Address : userToBeUpdated.Address;
            userToBeUpdated.City = user.City != null ? user.City : userToBeUpdated.City;
            userToBeUpdated.State = user.State != null ? user.State : userToBeUpdated.State;
            userToBeUpdated.Country = user.Country != null ? user.Country : userToBeUpdated.Country;

            switch (user.Gender)
            {
                case Gender.Male:
                    userToBeUpdated.Gender = Gender.Male;
                    break;
                case Gender.Female:
                    userToBeUpdated.Gender = Gender.Female;
                    break;
            }

            userToBeUpdated.Role = userToBeUpdated.Role;

            userToBeUpdated.Token = Guid.NewGuid().ToString();
            userToBeUpdated.InviteToken = null;
            userToBeUpdated.ConfirmToken = null;

            userToBeUpdated.ConnectionId = user.ConnectionId != null ? user.ConnectionId : null;

            userToBeUpdated.AdminId = userToBeUpdated.AdminId;
            userToBeUpdated.DoctorId = userToBeUpdated.DoctorId;
            userToBeUpdated.PatientId = userToBeUpdated.PatientId;

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return _mapper.Map<UserDTO>(userToBeUpdated);
            throw new Exception("Problem saving changes");
        }

        public async Task<UserDTO> UpdateAsync(int id, string newPassword, string confirmPassword, string currentPassword)
        {
            var user = await this.GetAsync(id);

            if (!string.IsNullOrWhiteSpace(currentPassword))
            {
                if (!Crypto.VerifyHashedPassword(user.Password, currentPassword))
                {
                    throw new RestException(HttpStatusCode.BadRequest, "Current password is not matching");
                }
                else if (currentPassword == newPassword)
                {
                    throw new RestException(HttpStatusCode.BadRequest, "New password cannot match current password!");
                }
            }

            if (newPassword != confirmPassword)
            {
                throw new RestException(HttpStatusCode.BadRequest, "Confirm Password should match the new password!");
            }

            user.Password = Crypto.HashPassword(newPassword);
            user.Token = Guid.NewGuid().ToString();
            user.InviteToken = null;

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return _mapper.Map<UserDTO>(user);
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
            if (user.Role == UserRole.Admin || user.Role == UserRole.Admin_Pharmcy) throw new RestException(HttpStatusCode.BadRequest, "The selector user is not able to be deleted.");

            if (user.Photo != null) await _cloudinaryService.DeleteAsync(user.Photo);

            switch (user.Role)
            {
                case UserRole.Doctor:
                    foreach (var url in user.Doctor.DoctorSocialMediaUrlLinks)
                    {
                        await _urlLink.DeleteAsync(url);
                    }
                    break;
            }

            _unitOfWork.User.Remove(user);
            await _unitOfWork.CommitAsync();
        }
        #endregion

        #region update token
        public async Task<UserDTO> TokenAsync(int id, string token)
        {
            var user = await _unitOfWork.User.SingleOrDefaultAsync(x => x.Id == id);
            user.Token = Guid.NewGuid().ToString();

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return _mapper.Map<UserDTO>(user);

            throw new Exception("Problem saving changes");
        }

        public async Task<UserDTO> InviteTokenAsync(User user)
        {
            user.InviteToken = user.InviteToken == null ? Guid.NewGuid().ToString() : null;
            var success = await _unitOfWork.CommitAsync() > 0;
            if (success)
            {
                if (user.InviteToken != null)
                {
                    var purpose = string.Empty;
                    var title = string.Empty;
                    var body = string.Empty;
                    var btn = false;
                    var url = string.Empty;

                    purpose = "Password reset process";
                    title = "'s password reset";
                    body = "To complete reset process click to the button!";
                    btn = true;

                    switch (user.Role)
                    {
                        case UserRole.Doctor:
                            url = $"/auth/reset-password/{user.InviteToken}";
                            break;
                        case UserRole.Patient:
                            url = $"/auth/reset-password/{user.InviteToken}";
                            break;
                    }

                    await _activityService.SendEmail(user, purpose, user.Fullname + title, body, btn, url);
                }

                return _mapper.Map<UserDTO>(user);
            }

            throw new Exception("Problem saving changes");
        }

        public async Task<UserDTO> ConfirmTokenAsync(string token)
        {
            var user = await this.GetAsync(token);
            user.ConfirmToken = user.ConfirmToken == null ? Guid.NewGuid().ToString() : null;

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return _mapper.Map<UserDTO>(user);
            throw new Exception("Problem saving changes");
        }

        public async Task ConnectionIdAsync(int id, string connectionId)
        {
            var user = await _unitOfWork.User.SingleOrDefaultAsync(x => x.Id == id);
            user.ConnectionId = connectionId;

            await _unitOfWork.CommitAsync();
        }
        #endregion

        #region photo upload
        public async Task<string> PhotoUploadAsync(int id, IFormFile file)
        {
            var user = await this.GetAsync(id);

            if (file == null) throw new RestException(HttpStatusCode.BadRequest, "File cannot be null");

            if (user.Photo == null && file != null)
            {
                user.Photo = await _cloudinaryService.Store(file);
            }
            else if (user.Photo != null && file != null)
            {
                await _cloudinaryService.DeleteAsync(user.Photo);
                user.Photo = await _cloudinaryService.Store(file);    
            }

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return user.Photo;
            throw new Exception("Problem saving changes");
        }
        #endregion
    }
}