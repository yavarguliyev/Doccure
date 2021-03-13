using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        public SettingRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }
    }
}