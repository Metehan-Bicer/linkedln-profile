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
    public class ExperienceService : IExperienceService
    {
        private readonly IMapper _mapper;
        private readonly LinkedlnProfileContext _context;

        public ExperienceService(IMapper mapper, LinkedlnProfileContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<ExperienceModel>> GetExperienceList(int userId)
        {
            List<ExperienceModel> userModel = new List<ExperienceModel>();

            userModel = await _mapper.ProjectTo<ExperienceModel>(_context.Experience.Where(x => x.UserId == userId)).ToListAsync();

            // todo mete her metoda try catch eklenecek log yapısı ekle

            return userModel;
        }
    }
}
