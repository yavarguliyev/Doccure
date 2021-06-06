using Core.DTOs.Main;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Core.Services.Rest
{
    public interface ICloudinaryService
    {
        Task<PhotoUploadResult> Store(IFormFile file);
        Task<string> DeleteAsync(string publicId);
    }
}