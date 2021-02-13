using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IDoctorService
    {
        Task<Doctor> GetAsync(int id);
        Task<Doctor> CreateAsync(Doctor newDoctor);
        Task UpdateAsync(Doctor doctorToBeUpdated, Doctor doctor);
        Task DeleteAsync(Doctor doctor);
    }
}