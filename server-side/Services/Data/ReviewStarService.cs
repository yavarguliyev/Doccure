using Core;
using Core.Models;
using Core.Services.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Data
{
    public class ReviewStarService : IReviewStarService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewStarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReviewStar> CreateAsync(ReviewStar newReviewStar)
        {
            newReviewStar.Status = true;
            newReviewStar.AddedDate = DateTime.Now;
            newReviewStar.ModifiedDate = DateTime.Now;
            newReviewStar.AddedBy = "System";
            newReviewStar.ModifiedBy = "System";

            newReviewStar.Star = newReviewStar.Star;
            newReviewStar.Number = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(newReviewStar.Star.Length * newReviewStar.Star.Split(",").Count()) / 10));
            newReviewStar.ReviewId = newReviewStar.ReviewId;

            await _unitOfWork.ReviewStar.AddAsync(newReviewStar);
            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return newReviewStar;

            throw new Exception("Problem saving changes");
        }
    }
}