using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IReviewReplyRepository : IRepository<ReviewReply>
    {
        Task<IEnumerable<ReviewReply>> Get();
        Task<ReviewReply> Get(int id);
    }
}