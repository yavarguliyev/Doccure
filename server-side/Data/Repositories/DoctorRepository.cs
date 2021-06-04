using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }

        public async Task<Doctor> Get(int id)
        {
            return await context.Doctors
                                .Where(x => x.Status)
                                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}