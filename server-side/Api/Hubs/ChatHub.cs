using Api.Hubs.ChatUsers;
using Core;
using Core.DTOs.Main;
using Core.Models;
using Core.Models.Hubs;
using Core.Services.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Hubs
{
    public class ChatHub : Hub
    {
        #region
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IChatService _chatService;
        private readonly IChatMessageService _chatMessageService;
        private readonly IHubContext<PresenceHub> _presenceHub;
        private readonly PresenceTracker _tracker;

        public ChatHub(IUnitOfWork unitOfWork,
                       IUserService userService,
                       IChatService chatService,
                       IChatMessageService chatMessageService,
                       IHubContext<PresenceHub> presenceHub,
                       PresenceTracker tracker)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _chatService = chatService;
            _chatMessageService = chatMessageService;
            _presenceHub = presenceHub;
            _tracker = tracker;
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
                        var groupNames = new List<string>();
                        await Groups.AddToGroupAsync(connectionId, groupName);
                        groupNames.Add(groupName);
                        var group = await AddToGroup(groupNames, user.Email);
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
                var group = await _unitOfWork.Group.GetGroupForConnection(user.Email);

                //await _chatMessageService.CreateAsync(message);
                var currentChat = await _chatService.GetAsync(message.ChatId, model.UserId);
                await Clients.Group(groupName).SendAsync("NewMessage", currentChat);
            }
        }

        private async Task<Group> AddToGroup(List<string> groupNames, string email)
        {
            foreach (var groupName in groupNames)
            {
                var group = await _unitOfWork.Group.GetMessageGroup(groupName);
                var connection = new Connection(Context.ConnectionId, email);

                if (group == null)
                {
                    group = new Group(groupName);
                    await _unitOfWork.Group.AddAsync(group);

                    if (group.Connections.Count() == 0) group.Connections.Add(connection);

                    if (await _unitOfWork.CommitAsync() > 0) return group;
                }
                else return group;
            }

            throw new HubException("Failed to join group");
        }

        private async Task<Group> RemoveFromMessageGroup()
        {
            var token = Context.GetHttpContext().Request.Query["token"].ToString();
            var user = await _userService.GetAsync(token);
            if (user != null)
            {
                var group = await _unitOfWork.Group.GetGroupForConnection(user.Email);
                var connections = group.Connections.Where(x => x.Email == user.Email).ToList();
                foreach (var connection in connections)
                {
                    _unitOfWork.Connection.Remove(connection);
                    if (await _unitOfWork.CommitAsync() > 0) return group;
                }
            }

            throw new HubException("Failed to remove from group");
        }

        private string GetGroupName(string caller, string other)
        {
            var stringCompare = string.CompareOrdinal(caller, other) < 0;
            return stringCompare ? $"{caller}-{other}" : $"{other}-{caller}";
        }
        #endregion
    }
}