using AutoMapper;
using Core;
using Core.DTOs.Admin.Admin_Setting;
using Core.Services.Data;
using Core.Services.Rest;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data
{
    public class SettingPhotoService : ISettingPhotoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryService _cloudinaryService;

        public SettingPhotoService(IMapper mapper,
                                   IUnitOfWork unitOfWork,
                                   ICloudinaryService cloudinaryService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<SettingPhotoDTO> GetAsync(string name)
        {
            return _mapper.Map<SettingPhotoDTO>(await _unitOfWork.SettingPhoto.Get(name));
        }

        public async Task<IEnumerable<SettingPhotoDTO>> GetAsync()
        {
            return _mapper.Map<IEnumerable<SettingPhotoDTO>>(await _unitOfWork.SettingPhoto.Get());
        }

        public async Task<string> PhotoUploadAsync(string name, IFormFile file)
        {
            var settingPhoto = await this.GetAsync(name);
            if (settingPhoto.Photo == null)
            {
                settingPhoto.Photo = await _cloudinaryService.Store(file);
            }
            else
            {
                await _cloudinaryService.DeleteAsync(settingPhoto.Photo);
                settingPhoto.Photo = await _cloudinaryService.Store(file);
            }

            var success = await _unitOfWork.CommitAsync() > 0;
            if (success) return settingPhoto.Photo;
            throw new Exception("Problem saving changes");
        }
    }
}