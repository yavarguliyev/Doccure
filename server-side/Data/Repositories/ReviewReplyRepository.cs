using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class ReviewReplyRepository : Repository<ReviewReply>, IReviewReplyRepository
    {
        public ReviewReplyRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }
    }
}