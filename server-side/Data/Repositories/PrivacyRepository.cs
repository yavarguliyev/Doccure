using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PrivacyRepository : Repository<Privacy>, IPrivacyRepository
    {
        public PrivacyRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }

        public async Task<Privacy> Get()
        {
            return await context.Privacies.Where(x => x.Status).FirstOrDefaultAsync();
        }
    }
}
