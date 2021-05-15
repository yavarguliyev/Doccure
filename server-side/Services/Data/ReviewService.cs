using AutoMapper;
using Core;
using Core.DTOs.Main;
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

        public ReviewService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ReviewDTO>> GetAsync(int id)
        {
            return _mapper.Map<IEnumerable<ReviewDTO>>(await _unitOfWork.Review.Get(id));
        }

        public async Task<ReviewDTO> GetAsync(int id, int userId)
        {
            return _mapper.Map<ReviewDTO>(await _unitOfWork.Review.Get(id, userId));
        }

        public async Task<ReviewDTO> CreateAsync(Review newReview)
        {
            newReview.Status = true;
            newReview.AddedDate = DateTime.Now;
            newReview.ModifiedDate = DateTime.Now;
            newReview.AddedBy = "System";
            newReview.ModifiedBy = "System";
            newReview.IsRecommended = false;
            newReview.IsReply = false;

            newReview.PatientId = newReview.PatientId;
            newReview.DoctorId = newReview.DoctorId;
            newReview.Text = newReview.Text;
            newReview.RateStar = newReview.RateStar;
            newReview.RateNumber = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(newReview.RateStar.Length * newReview.RateStar.Split(",").Count()) / 10));

            await _unitOfWork.Review.AddAsync(newReview);
            var success = await _unitOfWork.CommitAsync() > 0;
            if(success) return _mapper.Map<ReviewDTO>(newReview);
            throw new Exception("Problem saving changes");
        }
    }
}