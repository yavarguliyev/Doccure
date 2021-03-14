using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ISocialMediaRepository : IRepository<SocialMedia>
    {
        Task<SocialMedia> Get(string name);
        Task<IEnumerable<SocialMedia>> Get();
    }
}