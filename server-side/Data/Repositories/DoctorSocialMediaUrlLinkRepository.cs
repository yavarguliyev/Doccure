using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class DoctorSocialMediaUrlLinkRepository : Repository<DoctorSocialMediaUrlLink>, IDoctorSocialMediaUrlLinkRepository
    {
        public DoctorSocialMediaUrlLinkRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }
    }
}