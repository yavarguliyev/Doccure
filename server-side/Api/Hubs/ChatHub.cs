using Core.DTOs.Main;
using Core.Models;
using Core.Models.Hubs;
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
        private readonly IGroupService _groupService;
        private readonly IConnectionService _connectionService;
        private readonly IChatMessageService _chatMessageService;

        public ChatHub(IUserService userService,
                       IChatService chatService,
                       IGroupService groupService,
                       IConnectionService connectionService,
                       IChatMessageService chatMessageService)
        {
            _userService = userService;
            _chatService = chatService;
            _groupService = groupService;
            _connectionService = connectionService;
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
                var chats = await _chatService.GetAsync(user.Id);

                foreach (var chat in chats)
                {
                    var groupName = GetGroupName(chat.Doctor.Email, chat.Patient.Email);
                    if (!string.IsNullOrEmpty(groupName))
                    {
                        await Groups.AddToGroupAsync(connectionId, groupName);
                        var group = await AddToGroup(groupName);
                        await Clients.Group(groupName).SendAsync("UpdatedGroup", group);
                    }
                }

                await Clients.Caller.SendAsync("ReceiveMessageThread", chats);
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var group = await RemoveFromMessageGroup();
            await Clients.Group(group.Name).SendAsync("UpdatedGroup", group);
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

            var groupName = GetGroupName(chat.Doctor.Email, chat.Patient.Email);

            //await _chatMessageService.CreateAsync(message);
            var currentChat = await _chatService.GetAsync(message.ChatId, model.UserId);
            await Clients.Group(groupName).SendAsync("NewMessage", currentChat);
        }

        private async Task<Group> AddToGroup(string groupName)
        {
            var token = Context.GetHttpContext().Request.Query["token"].ToString();
            var user = await _userService.GetAsync(token);
            if (user != null)
            {
                var group = await _groupService.GetMessageGroupAsync(groupName);
                var connection = new Connection(Context.ConnectionId, user.Email);

                if (group == null)
                {
                    group = new Group(groupName);
                    _groupService.Add(group);
                }

                group.Connections.Add(connection);

                if (group != null) return group;
            }

            throw new HubException("Failed to join group");
        }

        private async Task<Group> RemoveFromMessageGroup()
        {
            var group = await _groupService.GetGroupForConnectionAsync(Context.ConnectionId);
            var connection = await _connectionService.GetConnectionAsync(Context.ConnectionId);
            await _connectionService.DeleteAsync(connection);
            if (connection == null) return group;

            throw new HubException("Failed to remove from group");
        }

        private string GetGroupName(string caller, string other)
        {
            var stringCompare = string.CompareOrdinal(caller, other) < 0;
            return stringCompare ? $"{caller}-{other}" : $"{other}-{caller}";
        }
    }
}