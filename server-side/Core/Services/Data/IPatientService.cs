using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IPatientService
    {
        Task<Patient> GetAsync(int id);
        Task<Patient> CreateAsync(Patient newPatient);
        Task UpdateAsync(int id, string token);
        Task UpdateAsync(Patient patientToBeUpdated, Patient patient);
    }
}