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
        public async Task<AbilitiesModel> SaveUpdateAbilities(AbilitiesModel abilitiesModel)
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
            // transaction.Commit();
            // todo mete her metoda try catch eklenecek log yapısı ekle ekleyince transaction aç

            return abilitiesModel;
        }

        public async Task<bool> DeleteAbilities(int id)
        {
            var dbItem = await _context.Abilities.Where(l => l.Id == id).FirstOrDefaultAsync();
            if (dbItem != null)
            {
                _context.Abilities.Remove(dbItem);
            }
            await _context.SaveChangesAsync();
            return true;
            //catch e düşürse false dön

        }
    }
}
