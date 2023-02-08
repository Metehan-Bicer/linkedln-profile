using AutoMapper;
using LinkedinProfileProject.Entities;
using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Mappers
{
    public class BaseMapper : Profile
    {
        public BaseMapper() : base()
        {
            CreateMap<City, CityModel>();


            CreateMap<District, DistrictModel>()
             .ForMember(destination => destination.CityName,
             options => options.MapFrom(source => source.City.CityName));
            


        }
    }
}
