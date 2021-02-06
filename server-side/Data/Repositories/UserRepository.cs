using Core.Models;
using Core.Repositories;
using Data.Errors;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }

        private DataContext context { get { return _context as DataContext; } }

        public async Task<User> Get(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                return user;
            }

            throw new RestException(HttpStatusCode.NotFound, new { user = "User not found" });
        }

        public async Task<User> GetByToken(string token)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Token == token);
            if (user != null)
            {
                return user;
            }

            throw new RestException(HttpStatusCode.NotFound, new { user = "User not found" });
        }

        public async Task<User> GetByInviteToken(string token)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.InviteToken == token);
            if (user != null)
            {
                return user;
            }

            throw new RestException(HttpStatusCode.NotFound, new { user = "User not found" });
        }

        public async Task<User> GetByConfirmToken(string token)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.ConfirmToken == token);
            if (user != null)
            {
                return user;
            }

            throw new RestException(HttpStatusCode.NotFound, new { user = "User not found" });
        }

        public async Task<User> GetBySlug(string slug)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Slug == slug);
            if (user != null)
            {
                return user;
            }

            throw new RestException(HttpStatusCode.NotFound, new { user = "User not found" });
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user != null)
            {
                return user;
            }

            throw new RestException(HttpStatusCode.NotFound, new { user = "User not found" });
        }

        public async Task<bool> CheckEmail(string email)
        {
            bool check = await context.Users.FirstOrDefaultAsync(x => x.Email == email) != null ? true : false;
            if (!check) return check;

            throw new RestException(HttpStatusCode.NotFound, new { user = "This email is already exist" });
        }
    }
}