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

    public async Task<IEnumerable<User>> Get(UserRole role, int? id)
    {
      var user = await context.Users.FirstOrDefaultAsync(x => x.Id == (id ?? default(int)));
      var users = context.Users.OrderByDescending(x => x.Id)
                         .Include(x => x.Admin)
                         .Include(x => x.Doctor)
                         .Include(x => x.Patient).ThenInclude(x => x.BloodGroup);

      if (user != null)
      {
        if (user.Role == UserRole.Admin)
          return await users.Where(x => x.Role == role).ToListAsync();
        else if (user.Role == UserRole.Doctor)
          return await users.Where(x => x.Status && x.Role == role).ToListAsync();
        else if (user.Role == UserRole.Patient)
          return await users.Where(x => x.Status && x.Role == role).ToListAsync();
      }

      return await users.Where(x => x.Status && x.Role == role).ToListAsync();
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

    public async Task<User> Get(string token)
    {
      if (string.IsNullOrEmpty(token)) throw new RestException(HttpStatusCode.BadRequest, new { user = "Token cannot be null" });

      var query = context.Users.Where(x => x.Status)
                               .Include(x => x.Admin)
                               .Include(x => x.Doctor)
                               .Include(x => x.Patient);

      var user = await query.FirstOrDefaultAsync(x => x.Token == token ||
                                                 x.InviteToken == token ||
                                                 x.ConfirmToken == token);
      if (user != null) return user;

      throw new RestException(HttpStatusCode.NotFound, new { user = "User not found" });
    }

    public async Task<User> GetBy(string queryValue)
    {
      if (string.IsNullOrEmpty(queryValue)) throw new RestException(HttpStatusCode.BadRequest, new { user = "User value cannot be null" });

      var query = context.Users.Where(x => x.Status)
                              .Include(x => x.Admin)
                              .Include(x => x.Doctor)
                              .Include(x => x.Patient);

      var user = await query.FirstOrDefaultAsync(x => x.Email == queryValue || x.Slug == queryValue);
      if (user != null) return user;

      throw new RestException(HttpStatusCode.NotFound, new { user = "User not found" });
    }

    public async Task<bool> Check(string queryValue)
    {
      if (string.IsNullOrEmpty(queryValue)) throw new RestException(HttpStatusCode.BadRequest, new { user = "Email cannot be null" });

      bool check = await context.Users
                              .Where(x => x.Status)
                              .Include(x => x.Admin)
                              .Include(x => x.Doctor)
                              .Include(x => x.Patient)
                              .FirstOrDefaultAsync(x => x.Email == queryValue || x.Slug == queryValue) != null ? true : false;

      if (check) throw new RestException(HttpStatusCode.BadRequest, new { user = "This user is already exist" });

      return true;
    }
  }
}