using AutoMapper;
using Azure;
using LinkedinProfileProject.Contexts;
using LinkedinProfileProject.Entities;
using LinkedinProfileProject.Interfaces;
using LinkedinProfileProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.NetworkInformation;

namespace LinkedinProfileProject.Services
{
    public class EducationService : IEducationService
    {
        private readonly IMapper _mapper;
        private readonly ILogService _logService;
        private readonly LinkedlnProfileContext _context;

        public EducationService(ILogService logService, IMapper mapper, LinkedlnProfileContext context)
        {
            _logService = logService;
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<EducationModel>> GetEducationList(int userId)
        {
            List<EducationModel> userModel = new List<EducationModel>();
            try
            {
                userModel = await _mapper.ProjectTo<EducationModel>(_context.Education.Where(x => x.UserId == userId)).ToListAsync();
            }
            catch (Exception e)
            {
                await _logService.LogException("GetEducationList", e);
            }

            return userModel;
        }
        public async Task<EducationModel> SaveUpdateEducation(EducationModel educationModel)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
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
                        tempEducation = _mapper.Map<Education>(educationModel);
                        _context.ChangeTracker.Clear();
                        _context.Update(tempEducation);
                    }
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    await _logService.LogException("SaveUpdateEducation", e);

                }
                return educationModel;
            }
        }
        public async Task<bool> DeleteEducation(int id)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var dbItem = await _context.Education.Where(l => l.Id == id).FirstOrDefaultAsync();
                    if (dbItem != null)
                    {
                        _context.Education.Remove(dbItem);
                    }
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    await _logService.LogException("DeleteEducation", e);
                    return false;
                }
                return true;
            }
        }
        public async Task<EducationModel> GetEducationById(int educationId)
        {
            EducationModel educationModel = new EducationModel();
            try
            {
                var tempEducation = await _context.Education.Where(x => x.Id == educationId).FirstOrDefaultAsync();
                educationModel = _mapper.Map<EducationModel>(tempEducation);
            }
            catch (Exception e)
            {
                await _logService.LogException("GetEducationById", e);
            }

            return educationModel;
        }
    }
}
