using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class PrivacyRepository : Repository<Privacy>, IPrivacyRepository
    {
        public PrivacyRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }
    }
}
