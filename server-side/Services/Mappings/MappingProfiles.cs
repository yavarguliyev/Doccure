using AutoMapper;
using Core.DTOs.Admin.Admin_Doctor;
using Core.DTOs.Admin.Admin_Setting;
using Core.DTOs.Auth;
using Core.DTOs.Doctor;
using Core.DTOs.Main;
using Core.Models;
using Services.Helpers;
using System.Linq;

namespace Services.Mappings
{
    public class MappingProfiles : Profile
    {
        private static string cloudinary = "https://res.cloudinary.com/dcqc5bx7c/image/upload/v1588180439/doccure/system/";

        public MappingProfiles()
        {
            CreateMap<User, UserDTO>()
                .ForMember(x => x.Age, opt => opt.MapFrom(src => src.Birth.CalculateAge()))
                .ForMember(x => x.FullAddress, opt => opt.MapFrom(src => src.City + ", " + src.Country))
                .ForMember(x => x.BloodGroup, opt => opt.MapFrom(src => src.Patient.BloodGroup.Name))
                .ForMember(x => x.Photo, opt => opt.MapFrom(src => src.Photo != null ? src.Photo : cloudinary + "avatar_vpbhfa.png"));

            CreateMap<Chat, ChatDTO>()
                .ForMember(x => x.ChatMessageDTOs, opt => opt.MapFrom(src => src.ChatMessages));
            CreateMap<ChatMessage, ChatMessageDTO>();

            CreateMap<Blog, BlogDTO>()
                .ForMember(x => x.Photo, opt => opt.MapFrom(src => src.Photo != null ? src.Photo : cloudinary + "blog-01_vffzcg.jpg"))
                .ForMember(x => x.Doctor, opt => opt.MapFrom(src => src.Doctor.Users.FirstOrDefault(x => x.DoctorId == src.DoctorId)));

            CreateMap<Setting, SettingDTO>()
                .ForMember(x => x.SocialMediaDTOs, opt => opt.MapFrom(src => src.SocialMedias));

            CreateMap<SettingPhoto, SettingPhotoDTO>()
                .ForMember(x => x.Photo, opt => opt.MapFrom(src => src.Photo != null ? src.Photo : cloudinary));

            CreateMap<Speciality, SpecialityDTO>()
                .ForMember(x => x.Photo, opt => opt.MapFrom(src => src.Photo != null ? src.Photo : cloudinary + "specialities-01_aieefa.png"));
            
            CreateMap<Feature, FeatureDTO>()
                .ForMember(x => x.Photo, opt => opt.MapFrom(src => src.Photo != null ? src.Photo : cloudinary + "feature-01_ejdasv.jpg"));

            CreateMap<UserProfileUpdateDTO, User>();
            CreateMap<AdminCreateDoctorDTO, User>();
            CreateMap<NewDoctorModifyDTO, User>();
            CreateMap<RegisterDTO, User>();

            CreateMap<DoctorSocialMediaUrlLink, DoctorSocialMediaUrlLinkDTO>();
            CreateMap<DoctorSocialMediaUrlLinkDTO, DoctorSocialMediaUrlLink>();

            CreateMap<SocialMedia, SocialMediaDTO>();
            CreateMap<Privacy, PrivacyDTO>();
            CreateMap<Term, TermDTO>();
        }
    }
}