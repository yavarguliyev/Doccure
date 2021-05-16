using Core.DTOs.Main;
using Core.Enum;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDTO>> GetAsync(int id);
        Task<ReviewDTO> GetAsync(int id, int userId);
        Task<ReviewDTO> CreateAsync(Review newReview);
        Task UpdateAsync(int id, int userId);
        Task UpdateAsync(int id, int userId, DoctorRecommendation recommendation);
    }
}