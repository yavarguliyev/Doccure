using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IPatientService
    {
        Task<Patient> GetAsync(int id);
        Task<Patient> CreateAsync(Patient newPatient);
        Task UpdateAsync(Patient patientToBeUpdated, Patient patient);
        Task DeleteAsync(Patient patient);
    }
}