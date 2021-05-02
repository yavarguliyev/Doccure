using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class ChatMessageRepository : Repository<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }
    }
}