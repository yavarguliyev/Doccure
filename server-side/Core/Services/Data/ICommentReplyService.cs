using Core.DTOs.Main;
using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface ICommentReplyService
    {
        Task<CommentReplyDTO> CreateAsync(CommentReply newCommentReply);
    }
}