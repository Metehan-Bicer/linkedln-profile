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
        public async Task<EducationModel> SaveUpdateEducation(EducationModel educationModel)
        {

            var tempEducation = await _context.Education.Where(x => x.Id == educationModel.Id).FirstOrDefaultAsync();
            if (tempEducation == null)
            {
                tempEducation = new Education();
                tempEducation = _mapper.Map<EducationModel, Education>(educationModel);
                _context.Education.Add(tempEducation);
            }
            else
            {
                tempEducation = _mapper.Map<Education>(tempEducation);
                _context.ChangeTracker.Clear();
                _context.Update(tempEducation);
            }
            await _context.SaveChangesAsync();
            // transaction.Commit();
            // todo mete her metoda try catch eklenecek log yapısı ekle ekleyince transaction aç

            return educationModel;
        }
        public async Task<bool> DeleteEducation(int id)
        {
            var dbItem = await _context.Education.Where(l => l.Id == id).FirstOrDefaultAsync();
            if (dbItem != null)
            {
                _context.Education.Remove(dbItem);
            }
            await _context.SaveChangesAsync();
            return true;
            //catch e düşürse false dön

        }
    }
}
