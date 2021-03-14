using AutoMapper;
using Core;
using Core.DTOs.Admin.Admin_Setting;
using Core.Models;
using Core.Services.Data;
using System;
using System.Threading.Tasks;

namespace Services.Data
{
    public class PrivacyService : IPrivacyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PrivacyService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PrivacyDTO> GetAsync()
        {
            return _mapper.Map<PrivacyDTO>(await _unitOfWork.Privacy.Get());
        }

        public async Task UpdateAsync(Privacy privacyToBeUpdated, Privacy privacy)
        {
            privacyToBeUpdated.Id = privacyToBeUpdated.Id;
            privacyToBeUpdated.Status = true;
            privacyToBeUpdated.AddedDate = privacyToBeUpdated.AddedDate;
            privacyToBeUpdated.ModifiedDate = DateTime.Now;
            privacyToBeUpdated.AddedBy = privacyToBeUpdated.AddedBy;
            privacyToBeUpdated.ModifiedBy = privacyToBeUpdated.ModifiedBy;

            privacyToBeUpdated.Heading = privacy.Heading != null ? privacy.Heading : privacyToBeUpdated.Heading;
            privacyToBeUpdated.SubHeading = privacy.SubHeading != null ? privacy.SubHeading : privacyToBeUpdated.SubHeading;
            privacyToBeUpdated.Body = privacy.Body != null ? privacy.Body : privacyToBeUpdated.Body;
            privacyToBeUpdated.BodySubHeading = privacy.BodySubHeading != null ? privacy.BodySubHeading : privacyToBeUpdated.BodySubHeading;
            privacyToBeUpdated.Footer = privacy.Footer != null ? privacy.Footer : privacyToBeUpdated.Footer;
            
            await _unitOfWork.CommitAsync();
        }
    }
}