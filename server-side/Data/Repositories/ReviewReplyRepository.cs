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
  public class ReviewReplyRepository : Repository<ReviewReply>, IReviewReplyRepository
  {
    public ReviewReplyRepository(DataContext context) : base(context) { }

    private DataContext Getcontext() { return Context as DataContext; }

    public async Task<IEnumerable<ReviewReply>> Get()
    {
      return await Getcontext().ReviewReplies
                          .Where(x => x.Status)
                          .OrderByDescending(x => x.AddedDate)
                          .Include(x => x.Patient)
                          .Include(x => x.Doctor)
                          .ToListAsync();
    }

    public async Task<ReviewReply> Get(int id)
    {
      if (id == 0) throw new RestException(HttpStatusCode.BadRequest, new { user = "Id cannot be null" });

      var reply = await Getcontext().ReviewReplies
                               .Where(x => x.Status)
                               .Include(x => x.Patient)
                               .Include(x => x.Doctor)
                               .FirstOrDefaultAsync(x => x.Id == id);
      if (reply == null) throw new RestException(HttpStatusCode.NotFound, new { user = "Review not found" });

      return reply;
    }
  }
}