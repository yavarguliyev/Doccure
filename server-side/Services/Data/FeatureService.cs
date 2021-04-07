using AutoMapper;
using Core;
using Core.DTOs.Main;
using Core.Services.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data
{
    public class FeatureService : IFeatureService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FeatureService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FeatureDTO>> GetAsync()
        {
            return _mapper.Map<IEnumerable<FeatureDTO>>(await _unitOfWork.Feature.Get());
        }
    }
}