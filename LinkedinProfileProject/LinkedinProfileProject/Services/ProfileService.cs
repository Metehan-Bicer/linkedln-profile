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
    public class ProfileService : IProfileService
    {
        private readonly IMapper _mapper;
        private readonly LinkedlnProfileContext _context;

        public ProfileService(IMapper mapper, LinkedlnProfileContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserModel> GetUser()
        {
            UserModel userModel = new UserModel();

            var tempUser = await _context.User.Include(x => x.District).ThenInclude(x => x.City).FirstOrDefaultAsync();
            userModel = _mapper.Map<UserModel>(tempUser);
            // todo mete her metoda try catch eklenecek log yapısı ekle

            return userModel;
        }
        public async Task<UserModel> SaveUpdateUser(UserModel userModel)
        {

            var tempUser = await _context.User.Where(x => x.Id == userModel.Id).FirstOrDefaultAsync();
            if (tempUser == null)
            {
                tempUser = new User();
                tempUser = _mapper.Map<UserModel, User>(userModel);
                _context.User.Add(tempUser);
            }
            else
            {
                tempUser = _mapper.Map<User>(userModel);
                _context.ChangeTracker.Clear();
                _context.Update(tempUser);
            }
            await _context.SaveChangesAsync();
            // transaction.Commit();
            // todo mete her metoda try catch eklenecek log yapısı ekle ekleyince transaction aç

            return userModel;
        }
    }
}
