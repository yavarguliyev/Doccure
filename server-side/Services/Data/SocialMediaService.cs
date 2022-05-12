using AutoMapper;
using Core;
using Core.DTOs.Admin.Admin_Setting;
using Core.Models;
using Core.Services.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data
{
  public class SocialMediaService : ISocialMediaService
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public SocialMediaService(IMapper mapper, IUnitOfWork unitOfWork)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
    }

    public async Task<SocialMedia> GetAsync(string name)
    {
      return await _unitOfWork.SocialMedia.Get(name);
    }

    public async Task<IEnumerable<SocialMediaDTO>> GetAsync()
    {
      return _mapper.Map<IEnumerable<SocialMediaDTO>>(await _unitOfWork.SocialMedia.Get());
    }

    public async Task UpdateAsync(SocialMedia socialMediaToBeUpdated, SocialMedia socialMedia)
    {
      socialMediaToBeUpdated.Id = socialMediaToBeUpdated.Id;
      socialMediaToBeUpdated.Status = true;
      socialMediaToBeUpdated.AddedDate = socialMediaToBeUpdated.AddedDate;
      socialMediaToBeUpdated.ModifiedDate = DateTime.Now;
      socialMediaToBeUpdated.AddedBy = socialMediaToBeUpdated.AddedBy;
      socialMediaToBeUpdated.ModifiedBy = socialMediaToBeUpdated.ModifiedBy;

      socialMediaToBeUpdated.Name = socialMedia.Name ?? socialMediaToBeUpdated.Name;
      socialMediaToBeUpdated.Icon = socialMedia.Icon ?? socialMediaToBeUpdated.Icon;
      socialMediaToBeUpdated.Link = socialMedia.Link ?? socialMediaToBeUpdated.Link;

      socialMediaToBeUpdated.SettingId = socialMediaToBeUpdated.SettingId;

      await _unitOfWork.CommitAsync();
    }
  }
}