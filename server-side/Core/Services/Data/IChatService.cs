using Core.DTOs.Main;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IChatService
    {
        Task<IEnumerable<ChatDTO>> GetAsync(int id);
        Task<ChatDTO> GetAsync(int id, int userId);
    }
}