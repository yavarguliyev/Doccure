using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class CommentReplyRepository : Repository<CommentReply>, ICommentReplyRepository
    {
        public CommentReplyRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }
    }
}