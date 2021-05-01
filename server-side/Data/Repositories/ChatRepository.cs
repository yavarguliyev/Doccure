using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class ChatRepository : Repository<Chat>, IChatRepository
    {
        public ChatRepository(DataContext context) : base(context) { }

        private DataContext context { get { return Context as DataContext; } }
    }
}