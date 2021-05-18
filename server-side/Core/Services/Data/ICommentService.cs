using Core.DTOs.Main;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> GetAsync(string slug);
        Task<CommentDTO> GetAsync(int id, string slug, int userId);
        Task<CommentDTO> CreateAsync(Comment newComment);
    }
}