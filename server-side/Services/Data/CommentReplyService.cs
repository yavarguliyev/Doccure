using AutoMapper;
using Core;
using Core.DTOs.Main;
using Core.Models;
using Core.Services.Data;
using System;
using System.Threading.Tasks;

namespace Services.Data
{
    public class CommentReplyService : ICommentReplyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentReplyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommentReplyDTO> CreateAsync(CommentReply newCommentReply)
        {
            newCommentReply.Status = true;
            newCommentReply.AddedDate = DateTime.Now;
            newCommentReply.ModifiedDate = DateTime.Now;
            newCommentReply.AddedBy = "System";
            newCommentReply.ModifiedBy = "System";

            newCommentReply.UserId = newCommentReply.UserId;
            newCommentReply.CommentId = newCommentReply.CommentId;
            newCommentReply.Text = newCommentReply.Text;

            await _unitOfWork.CommentReply.AddAsync(newCommentReply);
            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return _mapper.Map<CommentReplyDTO>(newCommentReply);

            throw new Exception("Problem saving changes");
        }
    }
}