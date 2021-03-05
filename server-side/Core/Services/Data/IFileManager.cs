using Microsoft.AspNetCore.Http;

namespace Core.Services.Data
{
    public interface IFileManager
    {
        string UploadPhoto(IFormFile file, string savePath = "uploads", string newName = null);
        void DeletePhoto(string fileName, string deletePath = "uploads");
    }
}