using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ISettingRepository : IRepository<Setting>
    {
        Task<Setting> Get();
    }
}