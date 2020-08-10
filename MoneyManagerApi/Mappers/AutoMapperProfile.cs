using AutoMapper;
using MoneyManagerApi.DTOs;
using MoneyManagerApi.Models;

namespace MoneyManagerApi.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
