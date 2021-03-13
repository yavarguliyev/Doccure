using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IDoctorService
    {
        Task<Doctor> GetAsync(int id);
        Task<int> CreateAsync(Doctor newDoctor);
        Task<Doctor> UpdateAsync(Doctor doctorToBeUpdated, Doctor doctor);
        Task DeleteAsync(Doctor doctor);
    }
}