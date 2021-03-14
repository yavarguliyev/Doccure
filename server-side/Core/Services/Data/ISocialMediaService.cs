using Core.DTOs.Admin.Admin_Setting;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface ISocialMediaService
    {
        Task<SocialMedia> GetAsync(string name);
        Task<IEnumerable<SocialMediaDTO>> GetAsync();
        Task UpdateAsync(SocialMedia socialMediaToBeUpdated, SocialMedia socialMedia);
    }
}