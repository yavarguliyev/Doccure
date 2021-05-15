﻿using AutoMapper;
using Core;
using Core.DTOs.Main;
using Core.Models;
using Core.Services.Data;
using System;
using System.Threading.Tasks;

namespace Services.Data
{
    public class ReviewReplyService : IReviewReplyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewReplyService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ReviewReplyDTO> CreateAsync(ReviewReply newReviewReply)
        {
            newReviewReply.Status = true;
            newReviewReply.AddedDate = DateTime.Now;
            newReviewReply.ModifiedDate = DateTime.Now;
            newReviewReply.AddedBy = "System";
            newReviewReply.ModifiedBy = "System";

            newReviewReply.ReviewId = newReviewReply.ReviewId;
            newReviewReply.PatientId = newReviewReply.PatientId;
            newReviewReply.DoctorId = newReviewReply.DoctorId;
            newReviewReply.Text = newReviewReply.Text;

            await _unitOfWork.ReviewReply.AddAsync(newReviewReply);
            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return _mapper.Map<ReviewReplyDTO>(newReviewReply);
            throw new Exception("Problem saving changes");
        }
    }
}