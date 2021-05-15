﻿using Core.DTOs.Main;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDTO>> GetAsync(int id);
        Task<ReviewDTO> GetAsync(int id, int userId);
        Task<ReviewDTO> CreateAsync(Review newReview);
    }
}