using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
  public class PatientRepository : Repository<Patient>, IPatientRepository
  {
    public PatientRepository(DataContext context) : base(context) { }

    private DataContext Getcontext() { return Context as DataContext; }

    public async Task<Patient> Get(int id)
    {
      return await Getcontext().Patients
                          .Include(x => x.BloodGroup)
                          .Where(x => x.Status)
                          .FirstOrDefaultAsync(x => x.Id == id);
    }
  }
}