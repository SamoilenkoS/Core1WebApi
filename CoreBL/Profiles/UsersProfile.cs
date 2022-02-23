using AutoMapper;
using Core1WebApi.Models;
using CoreDAL.Entities;
using System;

namespace CoreBL.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
              .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
              .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => DateTime.Parse(src.BirthDate)));

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToString()));
        }
    }
}
