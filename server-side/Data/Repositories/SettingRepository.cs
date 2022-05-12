using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
  public class SettingRepository : Repository<Setting>, ISettingRepository
  {
    public SettingRepository(DataContext context) : base(context) { }

    private DataContext Getcontext() { return Context as DataContext; }

    public async Task<Setting> Get()
    {
      return await Getcontext().Settings
                          .Where(x => x.Status)
                          .Include(x => x.SocialMedias)
                          .FirstOrDefaultAsync();
    }
  }
}