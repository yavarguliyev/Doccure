﻿using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IChatMessageRepository : IRepository<ChatMessage>
    {
        Task<IEnumerable<ChatMessage>> Get();
        Task<ChatMessage> GetBy(int id);
        Task<IEnumerable<ChatMessage>> Get(int id);
    }
}