using Core.Services.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Api.Hubs.ChatUsers
{
    public class PresenceHub : Hub
    {
        private readonly IUserService _userService;
        private readonly PresenceTracker _tracker;

        public PresenceHub(IUserService userService, PresenceTracker tracker)
        {
            _userService = userService;
            _tracker = tracker;
        }

        public override async Task OnConnectedAsync()
        {
            var token = Context.GetHttpContext().Request.Query["token"].ToString();
            var user = await _userService.GetAsync(token);
            if (user != null)
            {
                var isOnline = await _tracker.UserConnected(user.Email, Context.ConnectionId);
                if (isOnline) await Clients.Others.SendAsync("UserIsOnline", user.Email);

                var currentUsers = await _tracker.GetOnlineUsers();
                await Clients.Caller.SendAsync("GetOnlineUsers", currentUsers);
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var token = Context.GetHttpContext().Request.Query["token"].ToString();
            var user = await _userService.GetAsync(token);
            if (user != null)
            {
                var isOffline = await _tracker.UserDisconnected(user.Email, Context.ConnectionId);

                if (isOffline) await Clients.Others.SendAsync("UserIsOffline", user.Email);

                await base.OnDisconnectedAsync(exception);
            }
        }
    }
}
