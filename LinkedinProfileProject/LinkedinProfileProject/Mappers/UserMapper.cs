using AutoMapper;
using LinkedinProfileProject.Entities;
using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper() : base()
        {
            CreateMap<User, UserModel>()
             .ForMember(destination => destination.DistrictName,
             options => options.MapFrom(source => source.District.DistrictName))
             .ForMember(destination => destination.CityName,
             options => options.MapFrom(source => source.District.City.CityName));

            CreateMap<UserModel, User>();

        }
    }
}
