using Core.Models.Hubs;
using Core.Repositories;

namespace Data.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }
    }
}