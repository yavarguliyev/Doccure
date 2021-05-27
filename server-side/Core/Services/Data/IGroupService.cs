using Core.Models.Hubs;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IGroupService
    {
        Task<Group> GetMessageGroupAsync(string groupName);
        Task<Group> GetGroupForConnectionAsync(string connectionId);
        void Add(Group newGroup);
    }
}