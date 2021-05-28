using Core.Models.Hubs;
using Core.Repositories;
using System.Threading.Tasks;

namespace Core.Hubs.Repositories
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<Group> GetMessageGroup(string groupName);
        Task<Group> GetGroupForConnection(string email);
    }
}