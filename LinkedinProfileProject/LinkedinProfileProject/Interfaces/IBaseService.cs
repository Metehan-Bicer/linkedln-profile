using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Interfaces
{
    public interface IBaseService
    {
        Task<List<CityModel>> GetCity();
        Task<List<DistrictModel>> GetDistrictByCityId(int cityId);
    }
}
