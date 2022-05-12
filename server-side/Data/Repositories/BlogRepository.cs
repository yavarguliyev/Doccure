using Core.Helpers;
using Core.Models;
using Core.Repositories;
using Data.Errors;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Data.Repositories
{
  public class BlogRepository : Repository<Blog>, IBlogRespository
  {
    public BlogRepository(DataContext context) : base(context) { }

    private DataContext GetContext() { return base.Context as DataContext; }

    public async Task<PagedList<Blog>> Get(BlogParams blogParams)
    {
      var blogs = GetContext().Blogs.OrderByDescending(x => x.AddedDate)
                               .Include(x => x.Comments)
                               .Include(x => x.Doctor)
                               .ThenInclude(x => x.Users)
                               .Where(x => x.Status)
                               .AsQueryable();

      return await PagedList<Blog>.CreateAsync(blogs, blogParams.PageNumber, blogParams.PageSize);
    }

    public async Task<Blog> Get(string slug)
    {
      var blog = await GetContext().Blogs
                              .Where(x => x.Status)
                              .Include(x => x.Doctor)
                              .ThenInclude(x => x.Users)
                              .FirstOrDefaultAsync(x => x.Slug == slug);

      if (blog != null) return blog;

      throw new RestException(HttpStatusCode.NotFound, "Blog not found");
    }
  }
}