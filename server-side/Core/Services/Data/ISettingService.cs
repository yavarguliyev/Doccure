using Core.DTOs.Admin.Admin_Setting;
using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface ISettingService
    {
        Task<SettingDTO> GetAsync();
        Task UpdateAsync(Setting settingToBeUpdated, Setting setting);
    }
}