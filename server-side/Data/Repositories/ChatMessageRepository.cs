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
    public class ChatMessageRepository : Repository<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }

        public async Task<IEnumerable<ChatMessage>> Get()
        {
            return await context.ChatMessages
                                .Where(x => x.Status)
                                .OrderBy(x => x.AddedDate)
                                .ToListAsync();
        }

        public async Task<ChatMessage> GetBy(int id)
        {
            if (id == 0) throw new RestException(HttpStatusCode.BadRequest, new { user = "Id cannot be null" });

            var message =  await context.ChatMessages
                                .Where(x => x.Status)
                                .OrderBy(x => x.AddedDate)
                                .FirstOrDefaultAsync(x => x.Id == id);

            if (message == null) throw new RestException(HttpStatusCode.NotFound, new { user = "Message not found" });

            return message;
        }

        public async Task<IEnumerable<ChatMessage>> Get(int id)
        {
            return await context.ChatMessages
                                .Where(x => x.Status && x.ChatId == id)
                                .OrderBy(x => x.AddedDate)
                                .ToListAsync();
        }
    }
}