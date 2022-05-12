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
  public class CommentHub : Hub
  {
    #region comment
    private readonly IUserService _userService;
    private readonly IBlogService _blogService;
    private readonly ICommentService _commentService;
    private readonly ICommentReplyService _commentReplyService;

    public CommentHub(IUserService userService,
                      IBlogService blogService,
                      ICommentService commentService,
                      ICommentReplyService commentReplyService)
    {
      _userService = userService;
      _blogService = blogService;
      _commentService = commentService;
      _commentReplyService = commentReplyService;
    }

    public override async Task OnConnectedAsync()
    {
      var slug = Context.GetHttpContext().Request.Query["slug"].ToString();
      if (slug != null)
      {
        await Groups.AddToGroupAsync(Context.ConnectionId, slug);
        var comment = await _commentService.GetAsync(slug);
        await Clients.Caller.SendAsync("ReceiveCommentThread", comment);
      }
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
      await base.OnDisconnectedAsync(exception);
    }

    public async Task SendComment(CreateCommentDTO model)
    {
      var user = await _userService.GetByAsync(model.Email);
      if (user.Role != UserRole.Patient)
        throw new HubException("Only patients are able to comment on the blog.");

      var blog = await _blogService.GetAsync(model.Slug);

      var comment = new Comment
      {
        Text = model.Text,
        UserId = user.Id,
        BlogId = blog.Id
      };

      var newComment = await _commentService.CreateAsync(comment);
      await Clients.Group(blog.Slug).SendAsync("NewComment", newComment);
    }

    public async Task SendCommentReply(CreateReplyCommentDTO model)
    {
      var user = await _userService.GetByAsync(model.Email);
      if (user.Role != UserRole.Patient)
        throw new HubException("Only patients are able to comment on the blog.");

      var comment = await _commentService.GetAsync(model.CommentId, model.Slug);
      var reply = new CommentReply
      {
        UserId = user.Id,
        CommentId = comment.Id,
        Text = model.Text
      };

      if (!comment.CommentReplyDTOs.Any())
      {
        await _commentService.UpdateAsync(model.CommentId, model.Slug);
      }

      var newCommentReply = await _commentReplyService.CreateAsync(reply);
      await Clients.Group(model.Slug.ToString()).SendAsync("NewCommentReply", newCommentReply);
    }
    #endregion
  }
}