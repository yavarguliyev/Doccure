using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(DataContext context) : base(context) { }

        private DataContext context { get { return _context as DataContext; } }

        public async Task<Doctor> Get(int id)
        {
            return await context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}