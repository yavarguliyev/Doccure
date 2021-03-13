using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class SocialMediaRepository : Repository<SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }
    }
}