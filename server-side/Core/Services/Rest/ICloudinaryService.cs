using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Core.Services.Rest
{
    public interface ICloudinaryService
    {
        Task<string> Store(IFormFile file);
        Task<string> DeleteAsync(string publicId);
    }
}