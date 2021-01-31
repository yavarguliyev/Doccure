using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient> Get(int id);
    }
}