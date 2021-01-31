using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(DataContext context) : base(context) { }

        private DataContext context { get { return _context as DataContext; } }

        public async Task<Admin> Get(int id)
        {
            return await context.Admins.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}