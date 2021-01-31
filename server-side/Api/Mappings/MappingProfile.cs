using Api.DTOs.Auth;
using AutoMapper;
using Core.Models;
using System;

namespace Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(x => x.AdminId, opt => opt.MapFrom(src => src.AdminId))
                .ForMember(x => x.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                .ForMember(x => x.PatientId, opt => opt.MapFrom(src => src.PatientId))
                .ForMember(x => x.Birth, opt => opt.MapFrom(src => ((DateTime)src.Birth).ToString("MMM dd, yyyy")));

            CreateMap<RegisterDTO, User>();
        }
    }
}