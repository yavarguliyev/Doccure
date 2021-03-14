using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ISettingPhotoRepository : IRepository<SettingPhoto>
    {
        Task<SettingPhoto> Get(string name);
        Task<IEnumerable<SettingPhoto>> Get();
    }
}