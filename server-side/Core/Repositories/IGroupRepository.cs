using Core.Models.Hubs;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<Group> GetMessageGroup(string groupName);
        Task<Group> GetGroupForConnection(string connectionId);
    }
}