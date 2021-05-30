using Core.DTOs.Main;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IReviewReplyService
    {
        Task<IEnumerable<ReviewReplyDTO>> GetAsync();
        Task<ReviewReplyDTO> GetAsync(int id);
        Task<ReviewReplyDTO> CreateAsync(ReviewReply newReviewReply);
    }
}