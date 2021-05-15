using Core.DTOs.Main;
using Core.Enum;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
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
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendReview(CreateReviewDTO model)
        {
            var review = new Review
            {
                Text = model.Text,
                RateStar = model.RateStar,
                DoctorId = model.DoctorId,
                PatientId = model.PatientId
            };

            var newReview = await _reviewService.CreateAsync(review);
            await Clients.Caller.SendAsync("NewReview", newReview);
        }

        public async Task SendReviewReply(CreateReviewReplyDTO model)
        {
            var token = Context.GetHttpContext().Request.Query["token"].ToString();
            var user = await _userService.GetAsync(token);
            var review = new ReviewDTO();
            if (user.Role == UserRole.Doctor)
            {
                var id = user.DoctorId ?? default(int);
                review = await _reviewService.GetAsync(model.ReviewId, id);
            }
            else if (user.Role == UserRole.Patient)
            {
                var id = user.PatientId ?? default(int);
                review = await _reviewService.GetAsync(model.ReviewId, id);
            }

            if (review.ReviewReplyDTOs.Count() == 0)
            {
                review.IsReply = true;
            }

            var reply = new ReviewReply
            {
                ReviewId = review.Id,
                PatientId = model.PatientId,
                DoctorId = model.DoctorId,
                Text = model.Text
            };

            var newReply = await _reviewReplyService.CreateAsync(reply);
            await Clients.Caller.SendAsync("NewReviewReply", newReply);
        }
    }
}