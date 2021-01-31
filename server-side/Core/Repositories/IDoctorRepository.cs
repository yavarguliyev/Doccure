using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<Doctor> Get(int id);
    }
}
