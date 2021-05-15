using Core.DTOs.Main;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IUserService _userService;
        private readonly IChatService _chatService;
        private readonly IChatMessageService _chatMessageService;

        public ChatHub(IUserService userService, 
                       IChatService chatService, 
                       IChatMessageService chatMessageService)
        {
            _userService = userService;
            _chatService = chatService;
            _chatMessageService = chatMessageService;
        }

        public override async Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            var token = Context.GetHttpContext().Request.Query["token"].ToString();
            var user = await _userService.GetAsync(token);
            if (user != null)
            {
                await _userService.ConnectionIdAsync(user.Id, connectionId);
                var chat = await _chatService.GetAsync(user.Id);
                await Clients.Caller.SendAsync("ReceiveMessageThread", chat);
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            var token = Context.GetHttpContext().Request.Query["token"].ToString();
            var user = await _userService.GetAsync(token);
            if (user != null)
            {
                await _userService.ConnectionIdAsync(user.Id, connectionId);
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(CreateChatMessageDTO model)
        {
            var chat = await _chatService.GetAsync(model.ChatId, model.UserId);

            var message = new ChatMessage
            {
                DoctorContent = model.DoctorContent,
                PatientContent = model.PatientContent,
                Photo = model.Photo,
                ChatId = chat.Id
            };

            await _chatMessageService.CreateAsync(message);
            var currentChat = await _chatService.GetAsync(message.ChatId, model.UserId);
            await Clients.Caller.SendAsync("NewMessage", currentChat);
        }
    }
}