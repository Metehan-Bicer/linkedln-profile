using LinkedinProfileProject.Entities;
using LinkedinProfileProject.Models;

namespace LinkedinProfileProject.Interfaces
{
    public interface IBaseService
    {
        Task<List<CityModel>> GetCity();
        Task<List<DistrictModel>> GetDistrictByCityId(int cityId);
        Task<bool> SaveFile(IFormFile file, FileUploadModel fileUploadModel);
        Task<FileUploadModelImage> GetProfilePhoto(int userId);

    }
}
