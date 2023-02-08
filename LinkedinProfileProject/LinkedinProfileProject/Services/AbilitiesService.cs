using AutoMapper;
using Azure;
using LinkedinProfileProject.Contexts;
using LinkedinProfileProject.Entities;
using LinkedinProfileProject.Interfaces;
using LinkedinProfileProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace LinkedinProfileProject.Services
{
    public class AbilitiesService : IAbilitiesService
    {
        private readonly IMapper _mapper;
        private readonly LinkedlnProfileContext _context;

        public AbilitiesService(IMapper mapper, LinkedlnProfileContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<AbilitiesModel>> GetAbilitiesList(int userId)
        {
            List<AbilitiesModel> userModel = new List<AbilitiesModel>();

            userModel = await _mapper.ProjectTo<AbilitiesModel>(_context.Abilities.Where(x => x.UserId == userId)).ToListAsync();

            // todo mete her metoda try catch eklenecek log yapısı ekle

            return userModel;
        }
    }
}
