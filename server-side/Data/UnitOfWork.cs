using Core;
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

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IAdminRepository Admin => _adminRepository ??= new AdminRepository(_context);
        public IDoctorRepository Doctor => _doctorRepository ??= new DoctorRepository(_context);
        public IPatientRepository Patient => _patientRepository ??= new PatientRepository(_context);
        public IUserRepository User => _userRepository ??= new UserRepository(_context);

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