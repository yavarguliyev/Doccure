using Core;
using Core.Services.Data;

namespace Services.Data
{
    public class CommentReplyService : ICommentReplyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentReplyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}