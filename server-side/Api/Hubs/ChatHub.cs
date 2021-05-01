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

    public ChatHub(IUserService userService, IChatService chatService)
    {
      _userService = userService;
      _chatService = chatService;
    }

    public override async Task OnConnectedAsync()
    {
      var connectionId = Context.ConnectionId;
      var token = Context.GetHttpContext().Request.Query["token"].ToString();
      var user = await _userService.GetAsync(token);
      if (user != null)
      {
        await _userService.ConnectionIdAsync(user.Id, connectionId);
      }

      var chat = await _chatService.GetAsync(user.Id);
      await Clients.Caller.SendAsync("ReceiveMessageThread", chat);
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

    public async Task SendMessage()
    {
      await Clients.Group("").SendAsync("NewMessage", "");
    }
  }
}