using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IDoctorSocialMediaUrlLinkService
    {
        Task<DoctorSocialMediaUrlLink> GetAsync(int id);
        Task CreateAsync(DoctorSocialMediaUrlLink newUrlLink);
        Task UpdateAsync(DoctorSocialMediaUrlLink urlLinkToBeUpdated, DoctorSocialMediaUrlLink urlLink);
        Task DeleteAsync(DoctorSocialMediaUrlLink urlLink);
    }
}