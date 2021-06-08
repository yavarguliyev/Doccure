using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class ReviewStarRepository : Repository<ReviewStar>, IReviewStarRepository
    {
        public ReviewStarRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }
    }
}