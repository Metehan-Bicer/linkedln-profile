using LinkedinProfileProject.Interfaces;
using LinkedinProfileProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace LinkedinProfileProject.Controllers
{
    [Route("api/user")]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            this._profileService = profileService;
        }
        [HttpGet("getUser")]
        public async Task<UserModel> GetUser()
        {
            return await _profileService.GetUser();
        }
        [HttpGet("saveUpdateUser")]
        public async Task<UserModel> SaveUpdateUser([FromBody] UserModel userModel)
        {
            return await _profileService.SaveUpdateUser(userModel);
        }
    }
}
