using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IReviewStarService
    {
        Task<ReviewStar> CreateAsync(ReviewStar newReviewStar);
    }
}