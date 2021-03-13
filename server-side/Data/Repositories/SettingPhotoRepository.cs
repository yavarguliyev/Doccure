using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class SettingPhotoRepository : Repository<SettingPhoto>, ISettingPhotoRepository
    {
        public SettingPhotoRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }
    }
}