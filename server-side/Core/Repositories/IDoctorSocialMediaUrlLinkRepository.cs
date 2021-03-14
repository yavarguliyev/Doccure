using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IDoctorSocialMediaUrlLinkRepository : IRepository<DoctorSocialMediaUrlLink>
    {
        Task<DoctorSocialMediaUrlLink> Get(int id);
    }
}