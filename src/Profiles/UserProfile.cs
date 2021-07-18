using Api.DTOs;
using Api.Entities;
using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Source -> Target
            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserUpdateDTO>();
            CreateMap<User, AuthenticateResponse>();
        }

    }

}