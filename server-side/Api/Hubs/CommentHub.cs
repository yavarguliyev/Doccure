using Core.DTOs.Main;
using Core.Enum;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Api.Hubs
{
    public class CommentHub : Hub
    {
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
            var user = await _userService.GetAsync(model.UserId);
            if(user != null && user.Role != UserRole.Patient)
            {
                throw new HubException("Only patients are able to comment on the blog.");
            }

            var blog = await _blogService.GetAsync(model.Slug);

            var comment = new Comment
            {
                Text = model.Text,
                UserId = user.Id,
                BlogId = blog.Id
            };

            var newComment = await _commentService.CreateAsync(comment);
            await Clients.Caller.SendAsync("NewComment", newComment);
        }
    }
}