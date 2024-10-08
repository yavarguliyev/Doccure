﻿using AutoMapper;
using Core;
using Core.DTOs.Main;
using Core.Models;
using Core.Services.Data;
using Core.Services.Rest;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public ChatMessageService(IUnitOfWork unitOfWork,
                                  IMapper mapper,
                                  ICloudinaryService cloudinaryService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IEnumerable<ChatMessageDTO>> GetAsync()
        {
            return _mapper.Map<IEnumerable<ChatMessageDTO>>(await _unitOfWork.ChatMessage.Get());
        }

        public async Task<ChatMessage> GetByAsync(int id)
        {
            return await _unitOfWork.ChatMessage.GetBy(id);
        }

        public async Task<IEnumerable<ChatMessageDTO>> GetAsync(int id)
        {
            return _mapper.Map<IEnumerable<ChatMessageDTO>>(await _unitOfWork.ChatMessage.Get(id));
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
            newChatMessage.PhotoURL = newChatMessage.PhotoURL;
            newChatMessage.IsSeen = newChatMessage.IsSeen;

            await _unitOfWork.ChatMessage.AddAsync(newChatMessage);
            await _unitOfWork.CommitAsync();
        }

        public async Task<object> Upload(IFormFile file)
        {
            var upload = await _cloudinaryService.Store(file);
            return upload;
        }

        public async Task DeleteAsync(ChatMessage chatMessage)
        {
            if (chatMessage.Photo != null)
                await _cloudinaryService.DeleteAsync(chatMessage.Photo);

            _unitOfWork.ChatMessage.Remove(chatMessage);
            await _unitOfWork.CommitAsync();
        }
    }
}