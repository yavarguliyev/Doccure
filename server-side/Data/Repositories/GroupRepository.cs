using Core.Models.Hubs;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }

        public async Task<Group> GetGroupForConnection(string connectionId)
        {
            return await context.Groups
                                .Include(c => c.Connections)
                                .Where(c => c.Connections.Any(x => x.ConnectionId == connectionId))
                                .FirstOrDefaultAsync();
        }

        public async Task<Group> GetMessageGroup(string groupName)
        {
            return await context.Groups
                                 .Include(x => x.Connections)
                                 .FirstOrDefaultAsync(x => x.Name == groupName);
        }
    }
}