using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ITermRepository : IRepository<Term>
    {
        Task<Term> Get();
    }
}