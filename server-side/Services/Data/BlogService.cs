using AutoMapper;
using Core;
using Core.DTOs.Main;
using Core.Services.Data;
using System.Collections.Generic;
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
        public async Task<IEnumerable<BlogDTO>> GetAsync()
        {
            return _mapper.Map<IEnumerable<BlogDTO>>(await _unitOfWork.Blog.Get());
        }

        public async Task<BlogDTO> GetAsync(string slug)
        {
            return _mapper.Map<BlogDTO>(await _unitOfWork.Blog.Get(slug));
        }
        #endregion
    }
}