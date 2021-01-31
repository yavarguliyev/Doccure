using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DataContext context) : base(context) { }

        private DataContext context { get { return _context as DataContext; } }

        public async Task<Patient> Get(int id)
        {
            return await context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}