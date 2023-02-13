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
    public class ExperienceService : IExperienceService
    {
        private readonly IMapper _mapper;
        private readonly ILogService _logService;
        private readonly LinkedlnProfileContext _context;

        public ExperienceService(ILogService logService, IMapper mapper, LinkedlnProfileContext context)
        {
            _logService = logService;
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<ExperienceModel>> GetExperienceList(int userId)
        {
            List<ExperienceModel> experienceModel = new List<ExperienceModel>();
            try
            {
                experienceModel = await _mapper.ProjectTo<ExperienceModel>(_context.Experience.Where(x => x.UserId == userId)).ToListAsync();

            }
            catch (Exception e)
            {
                await _logService.LogException("GetExperienceList", e);
            }
            return experienceModel;
        }
        public async Task<ExperienceModel> GetExperienceById(int expId)
        {
            ExperienceModel experienceModel = new ExperienceModel();
            try
            {
                var tempExperience = await _context.Experience.Where(x => x.Id == expId).FirstOrDefaultAsync();
                experienceModel = _mapper.Map<ExperienceModel>(tempExperience);
            }
            catch (Exception e)
            {
                await _logService.LogException("GetExperienceById", e);
            }

            return experienceModel;
        }
        public async Task<ExperienceModel> SaveUpdateExperience(ExperienceModel experienceModel)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var tempExperience = await _context.Experience.Where(x => x.Id == experienceModel.Id).FirstOrDefaultAsync();
                    if (tempExperience == null)
                    {
                        tempExperience = new Experience();
                        tempExperience = _mapper.Map<ExperienceModel, Experience>(experienceModel);
                        _context.Experience.Add(tempExperience);
                    }
                    else
                    {
                        tempExperience = _mapper.Map<Experience>(experienceModel);

                        _context.ChangeTracker.Clear();
                        _context.Update(tempExperience);
                    }
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    await _logService.LogException("SaveUpdateExperience", e);

                }
            }
            return experienceModel;
        }
        public async Task<bool> DeleteExperience(int id)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var dbItem = await _context.Experience.Where(l => l.Id == id).FirstOrDefaultAsync();
                    if (dbItem != null)
                    {
                        _context.Experience.Remove(dbItem);
                    }
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    await _logService.LogException("DeleteExperience", e);
                    return false;
                }
            }
            return true;

        }
    }
}
