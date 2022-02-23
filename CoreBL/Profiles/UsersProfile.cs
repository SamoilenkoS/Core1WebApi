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
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();
        }
    }
}
