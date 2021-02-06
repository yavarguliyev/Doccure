using Core.DTOs.Auth;
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
                .ForMember(x => x.Birth, opt => opt.MapFrom(src => ((DateTime)src.Birth).ToString("MMM dd, yyyy")));

            CreateMap<RegisterDTO, User>();
            CreateMap<LoginDTO, User>();
        }
    }
}