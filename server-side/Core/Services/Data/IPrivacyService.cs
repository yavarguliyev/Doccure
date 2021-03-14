using Core.DTOs.Admin.Admin_Setting;
using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IPrivacyService
    {
        Task<PrivacyDTO> GetAsync();
        Task UpdateAsync(Privacy privacyToBeUpdated, Privacy privacy);
    }
}