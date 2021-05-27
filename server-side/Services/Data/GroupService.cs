using Core;
using Core.Models.Hubs;
using Core.Services.Data;
using System.Threading.Tasks;

namespace Services.Data
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Group> GetGroupForConnectionAsync(string connectionId)
        {
            return await _unitOfWork.Group.GetGroupForConnection(connectionId);
        }

        public async Task<Group> GetMessageGroupAsync(string groupName)
        {
            return await _unitOfWork.Group.GetMessageGroup(groupName);
        }

        public void Add(Group newGroup)
        {
            newGroup.Name = newGroup.Name;

            _unitOfWork.Group.AddAsync(newGroup);
            _unitOfWork.CommitAsync();
        }
    }
}