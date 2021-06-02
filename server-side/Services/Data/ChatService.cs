using AutoMapper;
using Core;
using Core.DTOs.Main;
using Core.Services.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data
{
    public class ChatService : IChatService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ChatService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ChatDTO>> GetAsync(int id)
        {
            return _mapper.Map<IEnumerable<ChatDTO>>(await _unitOfWork.Chat.Get(id));
        }

        public async Task<ChatDTO> GetAsync(int id, int userId)
        {
            return _mapper.Map<ChatDTO>(await _unitOfWork.Chat.Get(id, userId));
        }

        public async Task DeleteAsync(int chatId, int userId)
        {
            _unitOfWork.Chat.Remove(await _unitOfWork.Chat.Get(chatId, userId));
            await _unitOfWork.CommitAsync();
        }
    }
}