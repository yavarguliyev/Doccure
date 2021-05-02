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
                                      .OrderBy(x => x.AddedDate)
                                      .Include(x => x.Doctor)
                                      .Include(x => x.Patient)
                                      .Include(x => x.ChatMessages)
                                      .ToListAsync();

            return users;
        }

        public async Task<Chat> Get(int id, int userId)
        {
            if (id == 0) throw new RestException(HttpStatusCode.BadRequest, new { user = "Id cannot be null" });

            if (userId == 0) throw new RestException(HttpStatusCode.BadRequest, new { user = "User id cannot be null" });

            var chat = await context.Chats
                                    .Where(x => x.Status && (x.DoctorId == userId || x.PatientId == userId))
                                    .FirstOrDefaultAsync(x => x.Id == id);

            if (chat == null) throw new RestException(HttpStatusCode.NotFound, new { user = "Chat not found" });

            return chat;
        }
    }
}