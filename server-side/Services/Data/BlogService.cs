using AutoMapper;
using Core;
using Core.DTOs.Main;
using Core.Helpers;
using Core.Models;
using Core.Services.Data;
using System.Threading.Tasks;

namespace Services.Data
{
    public class BlogService : IBlogService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BlogService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #region get blog
        public async Task<PagedList<Blog>> GetAsync(BlogParams blogParams)
        {
            return await _unitOfWork.Blog.Get(blogParams);
        }

        public async Task<BlogDTO> GetAsync(string slug)
        {
            return _mapper.Map<BlogDTO>(await _unitOfWork.Blog.Get(slug));
        }
        #endregion
    }
}