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

            settingToBeUpdated.ContactNumber = setting.ContactNumber != null ? setting.ContactNumber : settingToBeUpdated.ContactNumber;
            settingToBeUpdated.Address = setting.Address != null ? setting.Address : settingToBeUpdated.Address;
            settingToBeUpdated.Email = setting.Email != null ? setting.Email : settingToBeUpdated.Email;
            settingToBeUpdated.FooterDesc = setting.FooterDesc != null ? setting.FooterDesc : settingToBeUpdated.FooterDesc;
            settingToBeUpdated.FooterSite = setting.FooterSite != null ? setting.FooterSite : settingToBeUpdated.FooterSite;
            
            settingToBeUpdated.HomeBannerTitle = setting.HomeBannerTitle != null ? setting.HomeBannerTitle : settingToBeUpdated.HomeBannerTitle;
            settingToBeUpdated.HomeBannerSubTitle = setting.HomeBannerSubTitle != null ? setting.HomeBannerSubTitle : settingToBeUpdated.HomeBannerSubTitle;
            settingToBeUpdated.ClinicAndSpecialitiesTitle = setting.ClinicAndSpecialitiesTitle != null ? setting.ClinicAndSpecialitiesTitle : settingToBeUpdated.ClinicAndSpecialitiesTitle;
            settingToBeUpdated.ClinicAndSpecialitiesSubTitle = setting.ClinicAndSpecialitiesSubTitle != null ? setting.ClinicAndSpecialitiesSubTitle : settingToBeUpdated.ClinicAndSpecialitiesSubTitle;
            settingToBeUpdated.PopularTitle = setting.PopularTitle != null ? setting.PopularTitle : settingToBeUpdated.PopularTitle;
            settingToBeUpdated.PopularSubTitle = setting.PopularSubTitle != null ? setting.PopularSubTitle : settingToBeUpdated.PopularSubTitle;
            settingToBeUpdated.PopularText = setting.PopularText != null ? setting.PopularText : settingToBeUpdated.PopularText;
            settingToBeUpdated.AvailableTitle = setting.AvailableTitle != null ? setting.AvailableTitle : settingToBeUpdated.AvailableTitle;
            settingToBeUpdated.AvailableSubTitle = setting.AvailableSubTitle != null ? setting.AvailableSubTitle : settingToBeUpdated.AvailableSubTitle;
            
            settingToBeUpdated.BlogsAndNewsTitle = setting.BlogsAndNewsTitle != null ? setting.BlogsAndNewsTitle : settingToBeUpdated.BlogsAndNewsTitle;
            settingToBeUpdated.BlogsAndNewsSubTitle = setting.BlogsAndNewsSubTitle != null ? setting.BlogsAndNewsSubTitle : settingToBeUpdated.BlogsAndNewsSubTitle;
            
            settingToBeUpdated.Information = setting.Information != null ? setting.Information : settingToBeUpdated.Information;

            await _unitOfWork.CommitAsync();
        }
    }
}