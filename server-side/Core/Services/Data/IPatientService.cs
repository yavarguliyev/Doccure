using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IPatientService
    {
        Task<Patient> GetAsync(int id);
        Task<int> CreateAsync(Patient newPatient);
        Task<Patient> UpdateAsync(Patient patientToBeUpdated, Patient patient);
        Task DeleteAsync(Patient patient);
    }
}