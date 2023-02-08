using AutoMapper;
using LinkedinProfileProject.Entities;
using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Mappers
{
    public class AbilitiesMapper : Profile
    {
        public AbilitiesMapper() : base()
        {
            CreateMap<Abilities, AbilitiesModel>();

            CreateMap<AbilitiesModel, Abilities>();

        }
    }
}
