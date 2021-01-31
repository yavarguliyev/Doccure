using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IAdminService
    {
        Task<Admin> GetAsync(int id);
        Task UpdateAsync(int id, string token);
        Task UpdateAsync(Admin adminToBeUpdated, Admin admin);
    }
}