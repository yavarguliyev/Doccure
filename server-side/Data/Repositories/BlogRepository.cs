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
    public class BlogRepository : Repository<Blog>, IBlogRespository
    {
        public BlogRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }

        public async Task<IEnumerable<Blog>> Get()
        {
            return await context.Blogs
                                .Include(x => x.Doctor)
                                .ThenInclude(x => x.Users)
                                .Where(x => x.Status)
                                .ToListAsync();
        }

        public async Task<Blog> Get(string slug)
        {
            var blog = await context.Blogs
                                    .Where(x => x.Status)
                                    .Include(x => x.Doctor)
                                    .ThenInclude(x => x.Users)
                                    .FirstOrDefaultAsync(x => x.Slug == slug);

            if (blog != null) return blog;

            throw new RestException(HttpStatusCode.NotFound, "Blog not found");
        }
    }
}