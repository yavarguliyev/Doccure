using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IPrivacyRepository : IRepository<Privacy>
    {
        Task<Privacy> Get();
    }
}