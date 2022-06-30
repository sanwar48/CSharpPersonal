using AutoMapper;
using Learningproject.DTOs;
using Learningproject.Models;

namespace Learningproject.Profiles
{
    public class UserReadDtoProfile : Profile
    {
        public UserReadDtoProfile()
        {
            // source => destination
            CreateMap<User, UserReadDto>();
        }
    }
}
