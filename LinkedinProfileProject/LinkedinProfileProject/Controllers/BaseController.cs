using LinkedinProfileProject.Interfaces;
using LinkedinProfileProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinkedinProfileProject.Controllers
{
    [Route("api/base")]
    public class BaseController : Controller
    {
        private readonly IBaseService _baseService;
        public BaseController(IBaseService baseService)
        {
            this._baseService = baseService;
        }
        [HttpGet("getCity")]
        public async Task<List<CityModel>> GetCity()
        {
            return await _baseService.GetCity();
        }
        [HttpGet("getDistrictByCityId/{cityId}")]
        public async Task<List<DistrictModel>> GetDistrictByCityId(int cityId)
        {
            return await _baseService.GetDistrictByCityId(cityId);
        }
    }
}
