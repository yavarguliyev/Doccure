using Core.Services.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Api.Hubs
{
    public class ReviewHub : Hub
    {
        private readonly IUserService _userService;
        private readonly IReviewService _reviewService;
        private readonly IReviewReplyService _reviewReplyService;

        public ReviewHub(IUserService userService,
                       IReviewService reviewService,
                       IReviewReplyService reviewReplyService)
        {
            _userService = userService;
            _reviewService = reviewService;
            _reviewReplyService = reviewReplyService;
        }

        public override async Task OnConnectedAsync()
        {
            var token = Context.GetHttpContext().Request.Query["token"].ToString();
            var user = await _userService.GetAsync(token);
            if (user != null)
            {
                var reviewDTOs = await _reviewService.GetAsync(user.Id);
                await Clients.Caller.SendAsync("ReceiveReviewThread", reviewDTOs);
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var token = Context.GetHttpContext().Request.Query["token"].ToString();
            var user = await _userService.GetAsync(token);
            if (user != null)
            {
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}