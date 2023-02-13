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
    public class ProfileService : IProfileService
    {
        private readonly IMapper _mapper;
        private readonly LinkedlnProfileContext _context;
        private readonly ILogService _logService;

        public ProfileService(ILogService logService, IMapper mapper, LinkedlnProfileContext context)
        {
            _logService = logService;
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserModel> GetUser()
        {
            UserModel userModel = new UserModel();
            try
            {
                var tempUser = await _context.User.Include(x => x.District).ThenInclude(x => x.City).FirstOrDefaultAsync();
                userModel = _mapper.Map<UserModel>(tempUser);
            }
            catch (Exception e)
            {
                await _logService.LogException("GetUser", e);
            }
            return userModel;
        }
        public async Task<UserModel> GetUserById(int userId)
        {
            UserModel userModel = new UserModel();
            try
            {
                var tempUser = await _context.User.Where(x => x.Id == userId).Include(x => x.District).ThenInclude(x => x.City).FirstOrDefaultAsync();
                userModel = _mapper.Map<UserModel>(tempUser);
            }
            catch (Exception e)
            {
                await _logService.LogException("GetUserById", e);
            }
            return userModel;
        }
        public async Task<UserModel> SaveUpdateUser(UserModel userModel)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
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
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    await _logService.LogException("SaveUpdateUser", e);

                }
            }
            return userModel;
        }
    }
}
