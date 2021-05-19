using Core.Models;
using Core.Repositories;
using Data.Errors;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }

        public async Task<IEnumerable<Comment>> Get(string slug)
        {
            if (string.IsNullOrEmpty(slug)) throw new RestException(HttpStatusCode.BadRequest, new { user = "Slug cannot be null" });

            var comments = await context.Comments
                                        .Where(x => x.Status && x.Blog.Slug == slug)
                                        .OrderByDescending(x => x.AddedDate)
                                        .Include(x => x.Blog)
                                        .Include(x => x.User)
                                        .Include(x => x.CommentReplies)
                                        .ToListAsync();

            return comments;
        }

        public async Task<Comment> Get(int id, string slug)
        {
            if (id == 0) throw new RestException(HttpStatusCode.BadRequest, new { user = "Id cannot be null" });

            if (string.IsNullOrEmpty(slug)) throw new RestException(HttpStatusCode.BadRequest, new { user = "Slug cannot be null" });

            var comment = await context.Comments
                                        .Where(x => x.Status)
                                        .Include(x => x.Blog)
                                        .FirstOrDefaultAsync(x => x.Id == id && x.Blog.Slug == slug);

            if (comment != null) return comment;

            throw new RestException(HttpStatusCode.NotFound, new { user = "Comment not found" });
        }
    }
}