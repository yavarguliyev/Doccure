using Core.DTOs.Main;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IChatMessageService
    {
        Task<IEnumerable<ChatMessageDTO>> GetAsync();
        Task<IEnumerable<ChatMessageDTO>> GetAsync(int id);
        Task CreateAsync(ChatMessage newChatMessage);
    }
}