using AutoMapper;
using Core;
using Core.DTOs.Admin.Admin_Setting;
using Core.Models;
using Core.Services.Data;
using System;
using System.Threading.Tasks;

namespace Services.Data
{
  public class SettingService : ISettingService
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public SettingService(IMapper mapper, IUnitOfWork unitOfWork)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
    }

    public async Task<SettingDTO> GetAsync()
    {
      return _mapper.Map<SettingDTO>(await _unitOfWork.Setting.Get());
    }

    public async Task UpdateAsync(Setting settingToBeUpdated, Setting setting)
    {
      settingToBeUpdated.Id = settingToBeUpdated.Id;
      settingToBeUpdated.Status = true;
      settingToBeUpdated.AddedDate = settingToBeUpdated.AddedDate;
      settingToBeUpdated.ModifiedDate = DateTime.Now;
      settingToBeUpdated.AddedBy = settingToBeUpdated.AddedBy;
      settingToBeUpdated.ModifiedBy = settingToBeUpdated.ModifiedBy;

      settingToBeUpdated.ContactNumber = setting.ContactNumber ?? settingToBeUpdated.ContactNumber;
      settingToBeUpdated.Address = setting.Address ?? settingToBeUpdated.Address;
      string v = setting.Email ?? settingToBeUpdated.Email;
      string v1 = v;
      settingToBeUpdated.Email = v1;
      settingToBeUpdated.FooterDesc = setting.FooterDesc ?? settingToBeUpdated.FooterDesc;
      settingToBeUpdated.FooterSite = setting.FooterSite ?? settingToBeUpdated.FooterSite;

      settingToBeUpdated.HomeBannerTitle = setting.HomeBannerTitle ?? settingToBeUpdated.HomeBannerTitle;
      settingToBeUpdated.HomeBannerSubTitle = setting.HomeBannerSubTitle ?? settingToBeUpdated.HomeBannerSubTitle;
      settingToBeUpdated.ClinicAndSpecialitiesTitle = setting.ClinicAndSpecialitiesTitle ?? settingToBeUpdated.ClinicAndSpecialitiesTitle;
      settingToBeUpdated.ClinicAndSpecialitiesSubTitle = setting.ClinicAndSpecialitiesSubTitle ?? settingToBeUpdated.ClinicAndSpecialitiesSubTitle;
      settingToBeUpdated.PopularTitle = setting.PopularTitle ?? settingToBeUpdated.PopularTitle;
      settingToBeUpdated.PopularSubTitle = setting.PopularSubTitle ?? settingToBeUpdated.PopularSubTitle;
      settingToBeUpdated.PopularText = setting.PopularText ?? settingToBeUpdated.PopularText;
      settingToBeUpdated.AvailableTitle = setting.AvailableTitle ?? settingToBeUpdated.AvailableTitle;
      settingToBeUpdated.AvailableSubTitle = setting.AvailableSubTitle ?? settingToBeUpdated.AvailableSubTitle;

      settingToBeUpdated.BlogsAndNewsTitle = setting.BlogsAndNewsTitle ?? settingToBeUpdated.BlogsAndNewsTitle;
      settingToBeUpdated.BlogsAndNewsSubTitle = setting.BlogsAndNewsSubTitle ?? settingToBeUpdated.BlogsAndNewsSubTitle;

      settingToBeUpdated.Information = setting.Information ?? settingToBeUpdated.Information;

      await _unitOfWork.CommitAsync();
    }
  }
}