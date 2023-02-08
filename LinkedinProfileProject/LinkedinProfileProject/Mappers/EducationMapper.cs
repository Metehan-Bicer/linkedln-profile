using AutoMapper;
using LinkedinProfileProject.Entities;
using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Mappers
{
    public class EducationMapper : Profile
    {
        public EducationMapper() : base()
        {
            CreateMap<Education, EducationModel>();

            CreateMap<EducationModel, Education>();

        }
    }
}
