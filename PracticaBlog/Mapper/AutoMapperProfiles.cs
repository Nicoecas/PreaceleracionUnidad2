using AutoMapper;
using PracticaBlog.Dtos;
using PracticaBlog.Entities;

namespace PracticaBlog.Mapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDbRegisterDto, UserDb>();
            CreateMap<UserDbLoginDto, UserDb>();
        }

    }
}
