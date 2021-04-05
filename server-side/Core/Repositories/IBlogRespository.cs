using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IBlogRespository : IRepository<Blog>
    {
        Task<IEnumerable<Blog>> Get();
        Task<Blog> Get(string slug);
    }
}