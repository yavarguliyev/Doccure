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
    public class ChatRepository : Repository<Chat>, IChatRepository
    {
        public ChatRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }

        public async Task<IEnumerable<Chat>> Get(int id)
        {
            if (id == 0) throw new RestException(HttpStatusCode.BadRequest, new { user = "Id cannot be null" });

            var users =  await context.Chats
                                      .Where(x => x.Status && (x.DoctorId == id || x.PatientId == id))
                                      .OrderByDescending(x => x.AddedDate)
                                      .Include(x => x.Doctor)
                                      .Include(x => x.Patient)
                                      .Include(x => x.ChatMessages)
                                      .ToListAsync();

            return users;
        }
    }
}