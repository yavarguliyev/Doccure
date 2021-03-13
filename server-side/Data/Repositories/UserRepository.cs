using Core.Enum;
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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }

        public async Task<IEnumerable<User>> Get(UserRole role)
        {
            return await context.Users
                                 .Where(x => x.Status && x.Role == role)
                                 .Include(x => x.Admin)
                                 .Include(x => x.Doctor)
                                 .Include(x => x.Patient)
                                 .ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            var user = await context.Users
                                    .Include(x => x.Admin)
                                    .Include(x => x.Doctor)
                                    .Include(x => x.Patient)
                                    .FirstOrDefaultAsync(x => x.Id == id);
            if (user != null) return user;

            throw new RestException(HttpStatusCode.NotFound, new { user = "User not found" });
        }

        public async Task<User> GetByToken(string token)
        {
            if (string.IsNullOrEmpty(token)) throw new RestException(HttpStatusCode.BadRequest, new { user = "Token cannot be null" });

            var user = await context.Users
                                    .Include(x => x.Admin)
                                    .Include(x => x.Doctor)
                                    .Include(x => x.Patient)
                                    .FirstOrDefaultAsync(x => x.Token == token);
            if (user != null) return user;

            throw new RestException(HttpStatusCode.NotFound, new { user = "User not found" });
        }

        public async Task<User> GetByInviteToken(string token)
        {
            if (string.IsNullOrEmpty(token)) throw new RestException(HttpStatusCode.BadRequest, new { user = "Token cannot be null" });

            var user = await context.Users
                                    .Include(x => x.Admin)
                                    .Include(x => x.Doctor)
                                    .Include(x => x.Patient)
                                    .FirstOrDefaultAsync(x => x.InviteToken == token);
            if (user != null) return user;

            throw new RestException(HttpStatusCode.NotFound, new { user = "User not found" });
        }

        public async Task<User> GetByConfirmToken(string token)
        {
            if (string.IsNullOrEmpty(token)) throw new RestException(HttpStatusCode.BadRequest, new { user = "Token cannot be null" });

            var user = await context.Users
                                    .Include(x => x.Admin)
                                    .Include(x => x.Doctor)
                                    .Include(x => x.Patient)
                                    .FirstOrDefaultAsync(x => x.ConfirmToken == token);
            if (user != null) return user;

            throw new RestException(HttpStatusCode.NotFound, new { user = "User not found" });
        }

        public async Task<User> GetBySlug(string slug)
        {
            if (string.IsNullOrEmpty(slug)) throw new RestException(HttpStatusCode.BadRequest, new { user = "Slug cannot be null" });

            var user = await context.Users
                                    .Include(x => x.Admin)
                                    .Include(x => x.Doctor)
                                    .Include(x => x.Patient)
                                    .FirstOrDefaultAsync(x => x.Slug == slug);
            if (user != null) return user;

            throw new RestException(HttpStatusCode.NotFound, new { user = "User not found" });
        }

        public async Task<User> GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new RestException(HttpStatusCode.BadRequest, new { user = "Email cannot be null" });

            var user = await context.Users
                                    .Include(x => x.Admin)
                                    .Include(x => x.Doctor)
                                    .Include(x => x.Patient)
                                    .FirstOrDefaultAsync(x => x.Email == email);
            if (user != null) return user;

            throw new RestException(HttpStatusCode.NotFound, new { user = "User not found" });
        }

        public async Task<bool> CheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new RestException(HttpStatusCode.BadRequest, new { user = "Email cannot be null" });

            bool check = await context.Users
                                    .Include(x => x.Admin)
                                    .Include(x => x.Doctor)
                                    .Include(x => x.Patient)
                                    .FirstOrDefaultAsync(x => x.Email == email) != null ? true : false;

            if (check) throw new RestException(HttpStatusCode.BadRequest, new { user = "This email is already exist" });

            return true;
        }
    }
}