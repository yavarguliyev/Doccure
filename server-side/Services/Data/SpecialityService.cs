using AutoMapper;
using Core;
using Core.DTOs.Main;
using Core.Services.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data
{
    public class SpecialityService : ISpecialityService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SpecialityService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SpecialityDTO>> GetAsync()
        {
            return _mapper.Map<IEnumerable<SpecialityDTO>>(await _unitOfWork.Speciality.Get());
        }
    }
}