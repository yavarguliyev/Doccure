using AutoMapper;
using Core;
using Core.DTOs.Main;
using Core.Enum;
using Core.Models;
using Core.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Data
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReviewStarService _reviewStarService;

        public ReviewService(IMapper mapper, IUnitOfWork unitOfWork, IReviewStarService reviewStarService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _reviewStarService = reviewStarService;
        }

        public async Task<IEnumerable<ReviewDTO>> GetAsync(int id)
        {
            return _mapper.Map<IEnumerable<ReviewDTO>>(await _unitOfWork.Review.Get(id));
        }

        public async Task<ReviewDTO> GetAsync(int id, int userId)
        {
            return _mapper.Map<ReviewDTO>(await _unitOfWork.Review.Get(id, userId));
        }

        public async Task<ReviewDTO> CreateAsync(CreateReviewDTO model)
        {
            var newReview = new Review();

            newReview.Status = true;
            newReview.AddedDate = DateTime.Now;
            newReview.ModifiedDate = DateTime.Now;
            newReview.AddedBy = "System";
            newReview.ModifiedBy = "System";
            newReview.IsReply = false;
            newReview.Recommendation = DoctorRecommendation.Select;

            newReview.PatientId = model.PatientId;
            newReview.DoctorId = model.DoctorId;
            newReview.Text = model.Text;

            await _unitOfWork.Review.AddAsync(newReview);
            var success = await _unitOfWork.CommitAsync() > 0;
            if (success)
            {
                var newReviewStar = new ReviewStar
                {
                    ReviewId = newReview.Id,
                    Star = model.RateStar
                };

                var reviewStar = await _reviewStarService.CreateAsync(newReviewStar);
                if (reviewStar != null) return _mapper.Map<ReviewDTO>(newReview);
            }

            throw new Exception("Problem saving changes");
        }

        public async Task UpdateAsync(int id, int userId)
        {
            var review = await _unitOfWork.Review.Get(id, userId);
            review.IsReply = true;

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int id, int userId, DoctorRecommendation recommendation)
        {
            var review = await _unitOfWork.Review.Get(id, userId);
            review.Recommendation = recommendation;

            await _unitOfWork.CommitAsync();
        }
    }
}