using Core.Helpers;
using Core.Models;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IBlogRespository : IRepository<Blog>
    {
        Task<PagedList<Blog>> Get(BlogParams blogParams);
        Task<Blog> Get(string slug);
    }
}