using Core.DTOs.Main;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> GetAsync(string slug);
        Task<CommentDTO> GetAsync(int id, string slug);
        Task<CommentDTO> CreateAsync(Comment newComment);
        Task UpdateAsync(int id, string slug);
    }
}