using Core.DTOs.Auth;
using AutoMapper;
using Core.Models;
using System;
using Core.DTOs.Admin.Admin_Doctor;

namespace Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(x => x.Birth, opt => opt.MapFrom(src => ((DateTime)src.Birth).ToString("MMM dd, yyyy")));

            CreateMap<AdminCreateDoctorDTO, User>();
            CreateMap<AdminNewDoctorModifyDTO, User>();

            CreateMap<RegisterDTO, User>();
            CreateMap<LoginDTO, User>();
        }
    }
}