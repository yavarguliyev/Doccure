using Core.Services.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Group("").SendAsync("", "");
            await Clients.Caller.SendAsync("", "");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.Group("").SendAsync("", "");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage()
        {
            await Clients.Group("").SendAsync("NewMessage", "");
        }
    }
}