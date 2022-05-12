using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
  public class AdminRepository : Repository<Admin>, IAdminRepository
  {
    public AdminRepository(DataContext context) : base(context) { }

    private DataContext GetContext() { return base.Context as DataContext; }

    public async Task<Admin> Get(int id)
    {
      return await GetContext().Admins.Where(x => x.Status).FirstOrDefaultAsync(x => x.Id == id);
    }
  }
}