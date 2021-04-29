using Core.DTOs.Main;
using Core.Helpers;
using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IBlogService
    {
        Task<PagedList<Blog>> GetAsync(BlogParams blogParams);
        Task<BlogDTO> GetAsync(string slug);
    }
}