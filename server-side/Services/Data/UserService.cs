using Core;
using Core.Enum;
using Core.Models;
using Core.Services.Data;
using CryptoHelper;
using Data.Errors;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Services.Data
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public UserService(IUnitOfWork unitOfWork, IDoctorService doctorService, IPatientService patientService)
        {
            _unitOfWork = unitOfWork;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        #region get user
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
        public async Task<User> UpdateAsync(int id, string token)
        {
            var user = await _unitOfWork.User.SingleOrDefaultAsync(x => x.Id == id);
            user.Token = Guid.NewGuid().ToString();

            await _unitOfWork.CommitAsync();

            return user;
        }

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
            newUser.Slug = newUser.Fullname.Replace(" ", "-").ToLower();
            newUser.Password = Crypto.HashPassword(newUser.Password);
            newUser.Token = null;
            newUser.InviteToken = null;
            newUser.ConfirmToken = Guid.NewGuid().ToString();
            newUser.AdminId = null;
            newUser.Role = role;

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

            await _unitOfWork.User.AddAsync(newUser);
            await _unitOfWork.CommitAsync();

            return newUser;
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

            userToBeUpdated.Password = user.Password != null ? Crypto.HashPassword(user.Password) : userToBeUpdated.Password;

            userToBeUpdated.Token = user.Token != null ? user.Token : userToBeUpdated.Token;
            userToBeUpdated.InviteToken = user.InviteToken != null ? user.InviteToken : userToBeUpdated.InviteToken;
            userToBeUpdated.ConfirmToken = user.ConfirmToken != null ? user.ConfirmToken : userToBeUpdated.ConfirmToken;
            userToBeUpdated.ConnectionId = user.ConnectionId != null ? user.ConnectionId : null;

            userToBeUpdated.Fullname = user.Fullname != null ? user.Fullname : userToBeUpdated.Fullname;
            userToBeUpdated.Slug = user.Slug != null ? user.Slug : userToBeUpdated.Slug;
            userToBeUpdated.Email = user.Email != null ? user.Email : userToBeUpdated.Email;
            userToBeUpdated.AdminId = user.AdminId != 0 ? user.AdminId : userToBeUpdated.AdminId;
            userToBeUpdated.DoctorId = user.DoctorId != 0 ? user.DoctorId : userToBeUpdated.DoctorId;
            userToBeUpdated.PatientId = user.PatientId != 0 ? user.PatientId : userToBeUpdated.PatientId;

            await _unitOfWork.CommitAsync();

            return userToBeUpdated;
        }
        #endregion
    }
}