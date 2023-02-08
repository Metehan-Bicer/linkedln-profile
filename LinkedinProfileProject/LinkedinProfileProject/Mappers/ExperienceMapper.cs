using AutoMapper;
using LinkedinProfileProject.Entities;
using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Mappers
{
    public class ExperienceMapper : Profile
    {
        public ExperienceMapper() : base()
        {
            CreateMap<Experience, ExperienceModel>();

            CreateMap<ExperienceModel, Experience>();

        }
    }
}
