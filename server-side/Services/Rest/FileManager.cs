using Core.Services.Rest;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Services.Data
{
    public class FileManager : IFileManager
    {
        #region
        public string UploadPhoto(IFormFile file, string savePath = "uploads", string newName = null)
        {
            var list = file.FileName.Split('.');

            string filename;

            if (newName == null)
                filename = Guid.NewGuid() + "." + list[^1];
            else
                filename = newName + "." + list[^1];

            var writePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", savePath);
            if (!Directory.Exists(writePath))
                Directory.CreateDirectory(writePath);

            var path = Path.Combine(writePath, filename);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return filename;
        }

        public void DeletePhoto(string fileName, string deletePath = "uploads")
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", deletePath, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        #endregion
    }
}