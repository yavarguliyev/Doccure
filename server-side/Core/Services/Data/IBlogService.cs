using Core.DTOs.Main;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDTO>> GetAsync();
        Task<BlogDTO> GetAsync(string slug);
    }
}