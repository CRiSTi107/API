using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Models;

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