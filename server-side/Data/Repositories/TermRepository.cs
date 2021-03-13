using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class TermRepository : Repository<Term>, ITermRepository
    {
        public TermRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }
    }
}