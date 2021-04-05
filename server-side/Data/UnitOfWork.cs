﻿using Core;
using Core.Repositories;
using Data.Repositories;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        private AdminRepository _adminRepository;
        private DoctorRepository _doctorRepository;
        private PatientRepository _patientRepository;
        private UserRepository _userRepository;

        private IBlogRespository _blogRespository;
        private IDoctorSocialMediaUrlLinkRepository _doctorSocialMediaUrlLinkRepository;
        private IPrivacyRepository _privacyRepository;
        private ISettingRepository _settingRepository;
        private ISettingPhotoRepository _settingPhotoRepository;
        private ISocialMediaRepository _socialMediaRepository;
        private ITermRepository _termRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IAdminRepository Admin => _adminRepository ??= new AdminRepository(_context);
        public IDoctorRepository Doctor => _doctorRepository ??= new DoctorRepository(_context);
        public IPatientRepository Patient => _patientRepository ??= new PatientRepository(_context);
        public IUserRepository User => _userRepository ??= new UserRepository(_context);

        public IBlogRespository Blog => _blogRespository ??= new BlogRepository(_context);
        public IDoctorSocialMediaUrlLinkRepository DoctorSocialMediaUrl => _doctorSocialMediaUrlLinkRepository ??= new DoctorSocialMediaUrlLinkRepository(_context);
        public IPrivacyRepository Privacy => _privacyRepository ??= new PrivacyRepository(_context);
        public ISettingRepository Setting => _settingRepository ??= new SettingRepository(_context);
        public ISettingPhotoRepository SettingPhoto => _settingPhotoRepository ??= new SettingPhotoRepository(_context);
        public ISocialMediaRepository SocialMedia => _socialMediaRepository ??= new SocialMediaRepository(_context);
        public ITermRepository Term => _termRepository ??= new TermRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}