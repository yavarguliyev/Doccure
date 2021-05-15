using Core;
using Core.Services.Data;

namespace Services.Data
{
    public class ReviewReplyService : IReviewReplyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewReplyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}