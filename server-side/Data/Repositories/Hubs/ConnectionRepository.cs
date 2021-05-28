using Core.Hubs.Repositories;
using Core.Models.Hubs;
using Data.Errors;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;

namespace Data.Hubs.Repositories
{
    public class ConnectionRepository : Repository<Connection>, IConnectionRepository
    {
        public ConnectionRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }

        public async Task<Connection> GetConnection(string email)
        {
            var connection = await context.Connections.FirstOrDefaultAsync(x => x.Email == email);
            if (connection != null) return connection;

            throw new RestException(HttpStatusCode.NotFound, "Connection not found");
        }
    }
}