using LinkedinProfileProject.Interfaces;
using LinkedinProfileProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace LinkedinProfileProject.Controllers
{
    [Route("api/abilities")]
    public class AbilitiesController : Controller
    {
        private readonly IAbilitiesService _abilitiesService;
        public AbilitiesController(IAbilitiesService abilitiesService)
        {
            this._abilitiesService = abilitiesService;
        }
        [HttpGet("getAbilitiesList/{userId}")]
        public async Task<List<AbilitiesModel>> GetAbilitiesList(int userId)
        {
            return await _abilitiesService.GetAbilitiesList(userId);
        }
    }
}
