using AutoMapper;
using Core.DTOs.Admin.Admin_Doctor;
using Core.DTOs.Admin.Admin_Setting;
using Core.DTOs.Auth;
using Core.DTOs.Doctor;
using Core.Models;
using System;

namespace Services.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDTO>()
                .ForMember(x => x.Birth, opt => opt.MapFrom(src => ((DateTime)src.Birth).ToString("MMM dd, yyyy")));

            CreateMap<UserProfileUpdateDTO, User>();
            CreateMap<AdminCreateDoctorDTO, User>();

            CreateMap<NewDoctorModifyDTO, User>();

            CreateMap<User, User>();
            CreateMap<RegisterDTO, User>();

            CreateMap<Setting, SettingDTO>();
            CreateMap<SettingPhoto, SettingPhotoDTO>();
            CreateMap<SocialMedia, SocialMediaDTO>();
            CreateMap<Privacy, PrivacyDTO>();
            CreateMap<Term, TermDTO>();
        }
    }
}