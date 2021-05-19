using AutoMapper;
using Core;
using Core.DTOs.Main;
using Core.Models;
using Core.Services.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDTO>> GetAsync(string slug)
        {
            return _mapper.Map<IEnumerable<CommentDTO>>(await _unitOfWork.Comment.Get(slug));
        }

        public async Task<CommentDTO> GetAsync(int id, string slug)
        {
            return _mapper.Map<CommentDTO>(await _unitOfWork.Comment.Get(id, slug));
        }

        public async Task<CommentDTO> CreateAsync(Comment newComment)
        {
            newComment.Status = true;
            newComment.AddedDate = DateTime.Now;
            newComment.ModifiedDate = DateTime.Now;
            newComment.AddedBy = "System";
            newComment.ModifiedBy = "System";
            newComment.IsReply = false;

            newComment.UserId = newComment.UserId;
            newComment.BlogId = newComment.BlogId;
            newComment.Text = newComment.Text;

            await _unitOfWork.Comment.AddAsync(newComment);
            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return _mapper.Map<CommentDTO>(newComment);

            throw new Exception("Problem saving changes");
        }

        public async Task UpdateAsync(int id, string slug)
        {
            var comment = await _unitOfWork.Comment.Get(id, slug);
            comment.IsReply = true;

            await _unitOfWork.CommitAsync();
        }
    }
}