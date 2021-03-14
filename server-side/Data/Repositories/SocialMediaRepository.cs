using Core.Models;
using Core.Repositories;
using Data.Errors;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SocialMediaRepository : Repository<SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }

        public async Task<SocialMedia> Get(string name)
        {
            return await context.SocialMedias
                                 .Where(x => x.Status)
                                 .Include(x => x.Setting)
                                 .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<SocialMedia>> Get()
        {
            var setting = await context.Settings.Where(x => x.Status).FirstOrDefaultAsync();
            if (setting == null) throw new RestException(HttpStatusCode.NotFound, "Not found");

            return await context.SocialMedias
                                .Where(x => x.Status && x.SettingId == setting.Id)
                                .Include(x => x.Setting)
                                .ToListAsync();
        }
    }
}