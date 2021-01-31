using Core.Models;
using Core.Repositories;
using CryptoHelper;
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

        public async Task<User> Get(string token)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Token == token);
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

        public async Task<bool> CheckEmail(string email)
        {
            bool check = await context.Users.FirstOrDefaultAsync(x => x.Email == email) != null ? true : false;
            if (!check) return check;

            throw new RestException(HttpStatusCode.NotFound, new { user = "This email is already exist" });
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
            {
                return user;
            }

            throw new RestException(HttpStatusCode.Unauthorized, new { user = "Invalid email or password" });
        }
    }
}