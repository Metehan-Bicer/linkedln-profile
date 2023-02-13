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
    public class AbilitiesService : IAbilitiesService
    {
        private readonly IMapper _mapper;
        private readonly LinkedlnProfileContext _context;
        private readonly ILogService _logService;


        public AbilitiesService(ILogService logService, IMapper mapper, LinkedlnProfileContext context)
        {
            _logService = logService;
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<AbilitiesModel>> GetAbilitiesList(int userId)
        {
            List<AbilitiesModel> abilitiesModel = new List<AbilitiesModel>();
            try
            {
                abilitiesModel = await _mapper.ProjectTo<AbilitiesModel>(_context.Abilities.Where(x => x.UserId == userId)).ToListAsync();
            }
            catch (Exception e)
            {
                await _logService.LogException("GetAbilitiesList", e);
            }
            return abilitiesModel;
        }
        public async Task<AbilitiesModel> SaveUpdateAbilities(AbilitiesModel abilitiesModel)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var tempAbilities = await _context.Abilities.Where(x => x.Id == abilitiesModel.Id).FirstOrDefaultAsync();
                    if (tempAbilities == null)
                    {
                        tempAbilities = new Abilities();
                        tempAbilities = _mapper.Map<AbilitiesModel, Abilities>(abilitiesModel);
                        _context.Abilities.Add(tempAbilities);
                    }
                    else
                    {
                        tempAbilities = _mapper.Map<Abilities>(abilitiesModel);
                        _context.ChangeTracker.Clear();
                        _context.Update(tempAbilities);
                    }
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    await _logService.LogException("SaveUpdateAbilities", e);

                }
            }
            return abilitiesModel;
        }

        public async Task<bool> DeleteAbilities(int id)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var dbItem = await _context.Abilities.Where(l => l.Id == id).FirstOrDefaultAsync();
                    if (dbItem != null)
                    {
                        _context.Abilities.Remove(dbItem);
                    }
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    await _logService.LogException("DeleteAbilities", e);
                    return false;
                }
            }
            return true;
        }
        public async Task<AbilitiesModel> GetAbilitiesById(int abilitiesId)
        {
            AbilitiesModel abilitiesModel = new AbilitiesModel();
            try
            {
                var temAbilities = await _context.Abilities.Where(x => x.Id == abilitiesId).FirstOrDefaultAsync();
                abilitiesModel = _mapper.Map<AbilitiesModel>(temAbilities);
            }
            catch (Exception e)
            {
                await _logService.LogException("GetAbilitiesById", e);

            }
            return abilitiesModel;
        }
    }
}
