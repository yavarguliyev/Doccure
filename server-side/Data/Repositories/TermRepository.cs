using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
  public class TermRepository : Repository<Term>, ITermRepository
  {
    public TermRepository(DataContext context) : base(context) { }

    private DataContext Getcontext() { return Context as DataContext; }

    public async Task<Term> Get()
    {
      return await Getcontext().Terms.Where(x => x.Status).FirstOrDefaultAsync();
    }
  }
}