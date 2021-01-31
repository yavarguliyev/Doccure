using Core.Repositories;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork
    {
        IAdminRepository Admin { get; }
        IDoctorRepository Doctor { get; }
        IPatientRepository Patient { get; }
        IUserRepository User { get; }

        Task<int> CommitAsync();
    }
}