using Core.DTOs.Main;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Hubs
{
    public class ChatHub : Hub
    {
        #region chat
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
                await Clients.Caller.SendAsync("OnlineUsers", user.ConnectionId);

                var chats = await _chatService.GetAsync(user.Id);

                foreach (var chat in chats)
                {
                    var groupName = GetGroupName(chat.Doctor.Email, chat.Patient.Email);
                    if (!string.IsNullOrEmpty(groupName))
                    {
                        var groupNames = new List<string>();
                        await Groups.AddToGroupAsync(connectionId, groupName);
                        groupNames.Add(groupName);
                        foreach (var item in groupNames)
                        {
                            await Clients.Group(groupName).SendAsync("UpdatedGroup", item);
                        }
                    }
                }

                
                await Clients.Caller.SendAsync("ReceiveMessageThread", chats);
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var token = Context.GetHttpContext().Request.Query["token"].ToString();
            var user = await _userService.GetAsync(token);
            if (user != null)
            {
                await _userService.ConnectionIdAsync(user.Id, null);
                await Clients.Caller.SendAsync("OfflineUsers", user.ConnectionId);
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(CreateChatMessageDTO model)
        {
            var token = Context.GetHttpContext().Request.Query["token"].ToString();
            var user = await _userService.GetAsync(token);
            if (user != null)
            {
                var chat = await _chatService.GetAsync(model.ChatId, model.UserId);

                var message = new ChatMessage
                {
                    DoctorContent = model.DoctorContent,
                    PatientContent = model.PatientContent,
                    Photo = model.Photo,
                    ChatId = chat.Id
                };

                var groupName = GetGroupName(chat.Doctor.Email, chat.Patient.Email);

                await _chatMessageService.CreateAsync(message);
                var currentChat = await _chatService.GetAsync(message.ChatId, model.UserId);
                await Clients.Group(groupName).SendAsync("NewMessage", currentChat);
            }
        }

        private string GetGroupName(string caller, string other)
        {
            var stringCompare = string.CompareOrdinal(caller, other) < 0;
            return stringCompare ? $"{caller}-{other}" : $"{other}-{caller}";
        }
        #endregion
    }
}