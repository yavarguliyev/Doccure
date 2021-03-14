using Core.DTOs.Admin.Admin_Setting;
using Core.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface ISettingPhotoService
    {
        Task<SettingPhotoDTO> GetAsync(string name);
        Task<IEnumerable<SettingPhotoDTO>> GetAsync();
        Task<string> PhotoUploadAsync(string name, IFormFile file);
    }
}