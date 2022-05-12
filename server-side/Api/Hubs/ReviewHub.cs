using Core.DTOs.Main;
using Core.Enum;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Hubs
{
  public class ReviewHub : Hub
  {
    #region review
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
      var connectionId = Context.ConnectionId;
      var token = Context.GetHttpContext().Request.Query["token"].ToString();
      var user = await _userService.GetAsync(token);
      if (user != null)
      {
        var slug = Context.GetHttpContext().Request.Query["slug"].ToString();
        await Groups.AddToGroupAsync(connectionId, slug);
        if (!string.IsNullOrEmpty(slug))
        {
          var groupNames = new List<string>();
          await Groups.AddToGroupAsync(connectionId, slug);
          groupNames.Add(slug);
          foreach (var item in groupNames)
          {
            await Clients.Group(slug).SendAsync("UpdatedGroup", item);
          }
        }

        var review = await _reviewService.GetAsync(user.Id);
        await Clients.Caller.SendAsync("ReceiveReviewThread", review);
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

      var slug = Context.GetHttpContext().Request.Query["slug"].ToString();
      if (!string.IsNullOrWhiteSpace(slug))
      {
        var newReview = await _reviewService.CreateAsync(review);
        await Clients.Group(slug).SendAsync("NewReview", newReview);
      }
    }

    public async Task SendReccomendation(int id, int userId, DoctorRecommendation recommendation)
    {
      await _reviewService.UpdateAsync(id, userId, recommendation);
      var slug = Context.GetHttpContext().Request.Query["slug"].ToString();
      if (!string.IsNullOrEmpty(slug))
      {
        await Clients.Group(slug).SendAsync("NewReccomendation", new { id, userId, recommendation });
      }
    }

    public async Task SendReviewReply(CreateReviewReplyDTO model)
    {
      var token = Context.GetHttpContext().Request.Query["token"].ToString();
      var user = await _userService.GetAsync(token);
      if (user != null)
      {
        var review = await _reviewService.GetAsync(model.ReviewId, user.Id);
        if (!review.ReviewReplyDTOs.Any())
        {
          await _reviewService.UpdateAsync(review.Id, review.DoctorId);
        }

        var reply = new ReviewReply
        {
          ReviewId = review.Id,
          PatientId = model.PatientId,
          DoctorId = model.DoctorId,
          Text = model.Text
        };

        var slug = Context.GetHttpContext().Request.Query["slug"].ToString();
        if (!string.IsNullOrEmpty(slug))
        {
          var newReply = await _reviewReplyService.CreateAsync(reply);
          await Clients.Group(slug).SendAsync("NewReviewReply", newReply);
        }

      }
    }
    #endregion
  }
}