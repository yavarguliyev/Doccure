using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Task<Admin> Get(int id);
    }
}