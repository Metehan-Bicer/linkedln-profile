using AutoMapper;
using Azure;
using LinkedinProfileProject.Contexts;
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
            UserModel userModel= new UserModel();

            var tempUser= await this._context.User.FirstOrDefaultAsync();
            userModel =  _mapper.Map<UserModel>(tempUser);

            return userModel;
        }
    }
}
