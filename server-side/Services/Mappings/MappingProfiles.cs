using AutoMapper;
using Core.DTOs.Admin.Admin_Doctor;
using Core.DTOs.Admin.Admin_Setting;
using Core.DTOs.Auth;
using Core.DTOs.Doctor;
using Core.DTOs.Main;
using Core.Models;
using System;
using System.Linq;

namespace Services.Mappings
{
    public class MappingProfiles : Profile
    {
        private static string cloudinary = "https://res.cloudinary.com/dcqc5bx7c/image/upload/v1588180439/doccure/system/";

        public MappingProfiles()
        {
            CreateMap<User, UserDTO>()
                .ForMember(x => x.Birth, opt => opt.MapFrom(src => ((DateTime)src.Birth).ToString("MMM dd, yyyy")))
                .ForMember(x => x.Photo, opt => opt.MapFrom(src => src.Photo != null ? src.Photo : cloudinary + "avatar_vpbhfa.png"));

            CreateMap<UserProfileUpdateDTO, User>();
            CreateMap<AdminCreateDoctorDTO, User>();

            CreateMap<NewDoctorModifyDTO, User>();

            CreateMap<RegisterDTO, User>();

            CreateMap<Blog, BlogDTO>()
                .ForMember(x => x.Photo, opt => opt.MapFrom(src => src.Photo != null ? src.Photo : cloudinary + "blog-01_vffzcg.jpg"))
                .ForMember(x => x.Doctor, opt => opt.MapFrom(src => src.Doctor.Users.FirstOrDefault(x => x.DoctorId == src.DoctorId)));

            CreateMap<Setting, SettingDTO>()
                .ForMember(x => x.SocialMediaDTOs, opt => opt.MapFrom(src => src.SocialMedias));

            CreateMap<SettingPhoto, SettingPhotoDTO>();
            CreateMap<SocialMedia, SocialMediaDTO>();
            CreateMap<Privacy, PrivacyDTO>();
            CreateMap<Term, TermDTO>();

            CreateMap<Speciality, SpecialityDTO>()
                .ForMember(x => x.Photo, opt => opt.MapFrom(src => src.Photo != null ? src.Photo : cloudinary + "specialities-01_aieefa.png"));
            
            CreateMap<Feature, FeatureDTO>()
                .ForMember(x => x.Photo, opt => opt.MapFrom(src => src.Photo != null ? src.Photo : cloudinary + "feature-01_ejdasv.jpg"));
        }
    }
}