using AutoMapper;
using Core;
using Core.DTOs.Main;
using Core.Services.Data;
using System.Collections.Generic;
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
    }
}