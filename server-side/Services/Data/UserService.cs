using Core;
using Core.Enum;
using Core.Models;
using Core.Services.Data;
using System;
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

        public async Task<User> GetAsync(int id)
        {
            return await _unitOfWork.User.Get(id);
        }

        public async Task<User> GetAsync(string token)
        {
            return await _unitOfWork.User.Get(token);
        }

        public async Task<User> GetBySlugAsync(string slug)
        {
            return await _unitOfWork.User.GetBySlug(slug);
        }

        public async Task<User> GetByCodeAsync(string code)
        {
            return await _unitOfWork.User.SingleOrDefaultAsync(x => x.Code == code);
        }

        public async Task<bool> CheckEmailAsync(string email)
        {
            return await _unitOfWork.User.CheckEmail(email);
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            return await _unitOfWork.User.Login(email, password);
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
            newUser.Password = null;
            newUser.Token = null;
            newUser.InviteToken = Guid.NewGuid().ToString();
            newUser.ConfirmToken = null;
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

        public Task UpdateAsync(int id, string token)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User userToBeUpdated, User user)
        {
            throw new NotImplementedException();
        }
    }
}