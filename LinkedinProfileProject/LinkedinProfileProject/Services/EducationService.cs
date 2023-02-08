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
    public class EducationService : IEducationService
    {
        private readonly IMapper _mapper;
        private readonly LinkedlnProfileContext _context;

        public EducationService(IMapper mapper, LinkedlnProfileContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<EducationModel>> GetEducationList(int userId)
        {
            List<EducationModel> userModel = new List<EducationModel>();

            userModel = await _mapper.ProjectTo<EducationModel>(_context.Education.Where(x => x.UserId == userId)).ToListAsync();

            // todo mete her metoda try catch eklenecek log yapısı ekle

            return userModel;
        }
    }
}
