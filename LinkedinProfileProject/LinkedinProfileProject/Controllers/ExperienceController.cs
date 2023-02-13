using LinkedinProfileProject.Interfaces;
using LinkedinProfileProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace LinkedinProfileProject.Controllers
{
    [Route("api/experience")]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;
        public ExperienceController(IExperienceService experienceService)
        {
            this._experienceService = experienceService;
        }
        [HttpGet("getExperienceList/{userId}")]
        public async Task<List<ExperienceModel>> GetExperienceList(int userId)
        {
            return await _experienceService.GetExperienceList(userId);
        }
        [HttpGet("getExperienceById/{expId}")]
        public async Task<ExperienceModel> GetExperienceById(int expId)
        {
            return await _experienceService.GetExperienceById(expId);
        }
        [HttpPost("saveUpdateExperience")]
        public async Task<ExperienceModel> SaveUpdateExperience([FromBody] ExperienceModel experienceModel)
        {
            return await _experienceService.SaveUpdateExperience(experienceModel);
        }
        [HttpPost("deleteExperienceById")]
        public async Task<bool> DeleteExperienceUserId([FromBody] int id)
        {
            return await _experienceService.DeleteExperience(id);
        }
    }
}
