using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IChatMessageService
    {
        Task CreateAsync(ChatMessage newChatMessage);
    }
}