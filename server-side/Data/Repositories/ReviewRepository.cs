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
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }

        public async Task<IEnumerable<Review>> Get(int id)
        {
            if (id == 0) throw new RestException(HttpStatusCode.BadRequest, new { user = "Id cannot be null" });

            var reviews = await context.Reviews
                                       .Where(x => x.Status && x.DoctorId == id)
                                       .OrderByDescending(x => x.AddedDate)
                                       .Include(x => x.Patient)
                                       .Include(x => x.ReviewReplies.OrderByDescending(r => r.AddedDate))
                                       .Include(x => x.ReviewStars)
                                       .ToListAsync();

            return reviews;
        }

        public async Task<Review> Get(int id, int userId)
        {
            if (id == 0) throw new RestException(HttpStatusCode.BadRequest, new { user = "Id cannot be null" });

            if (userId == 0) throw new RestException(HttpStatusCode.BadRequest, new { user = "User id cannot be null" });

            var review = await context.Reviews
                                    .Where(x => x.Status && (x.DoctorId == userId || x.PatientId == userId))
                                    .Include(x => x.ReviewReplies)
                                    .Include(x => x.Patient)
                                    .Include(x => x.ReviewStars)
                                    .FirstOrDefaultAsync(x => x.Id == id);

            if (review == null) throw new RestException(HttpStatusCode.NotFound, new { user = "Review not found" });

            return review;
        }
    }
}