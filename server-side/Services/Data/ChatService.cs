using AutoMapper;
using Core;
using Core.DTOs.Main;
using Core.Services.Data;
using Core.Services.Rest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data
{
    public class ChatService : IChatService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryService _cloudinaryService;

        public ChatService(IMapper mapper,
                           IUnitOfWork unitOfWork,
                           ICloudinaryService cloudinaryService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cloudinaryService = cloudinaryService;
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
            var chat = await _unitOfWork.Chat.GetBy(chatId, userId);

            foreach (var message in chat.ChatMessages)
            {
                if (message.Photo != null)
                    await _cloudinaryService.DeleteAsync(message.Photo);

                _unitOfWork.ChatMessage.Remove(message);
            }

            _unitOfWork.Chat.Remove(chat);
            await _unitOfWork.CommitAsync();
        }
    }
}