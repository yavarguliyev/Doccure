using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }
    }
}