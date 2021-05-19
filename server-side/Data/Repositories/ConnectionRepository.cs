using Core.Models.Hubs;
using Core.Repositories;

namespace Data.Repositories
{
    public class ConnectionRepository : Repository<Connection>, IConnectionRepository
    {
        public ConnectionRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }
    }
}