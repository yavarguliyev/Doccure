using Core;
using Core.Models;
using Core.Services.Data;
using System;
using System.Threading.Tasks;

namespace Services.Data
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChatMessageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(ChatMessage newChatMessage)
        {
            newChatMessage.Status = true;
            newChatMessage.AddedDate = DateTime.Now;
            newChatMessage.ModifiedDate = DateTime.Now;
            newChatMessage.AddedBy = "System";
            newChatMessage.ModifiedBy = "System";

            newChatMessage.ChatId = newChatMessage.ChatId;
            newChatMessage.DoctorContent = newChatMessage.DoctorContent;
            newChatMessage.PatientContent = newChatMessage.PatientContent;
            newChatMessage.Photo = newChatMessage.Photo;
            newChatMessage.IsSeen = newChatMessage.IsSeen;

            await _unitOfWork.ChatMessage.AddAsync(newChatMessage);
            await _unitOfWork.CommitAsync();
        }
    }
}