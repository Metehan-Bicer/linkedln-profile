using System.Data;
using AutoMapper;
using LinkedinProfileProject.Contexts;
using LinkedinProfileProject.Entities;
using LinkedinProfileProject.Interfaces;
using LinkedinProfileProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkedinProfileProject.Services
{
    public class BaseService : IBaseService
    {
        private readonly IMapper _mapper;
        private readonly LinkedlnProfileContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogService _logService;

        public BaseService(ILogService logService, IMapper mapper, LinkedlnProfileContext context, IConfiguration configuration)
        {
            _logService = logService;
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
        }
        public async Task<List<CityModel>> GetCity()
        {
            List<CityModel> cityModel = new List<CityModel>();
            try
            {
                cityModel = await _mapper.ProjectTo<CityModel>(_context.City).ToListAsync();
            }
            catch (Exception e)
            {
                await _logService.LogException("GetCity", e);

            }
            return cityModel;
        }
        public async Task<List<DistrictModel>> GetDistrictByCityId(int cityId)
        {
            List<DistrictModel> districtModel = new List<DistrictModel>();
            try
            {
                districtModel = await _mapper.ProjectTo<DistrictModel>(_context.District.Where(x => x.CityId == cityId).Include(x => x.City)).ToListAsync();
            }
            catch (Exception e)
            {
                await _logService.LogException("GetDistrictByCityId", e);

            }
            return districtModel;
        }
        public async Task<bool> SaveFile(IFormFile file, FileUploadModel fileUploadModel)
        {
            bool result = new bool();
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var fileExtension = Path.GetExtension(file.FileName);
                    var newFileName = Guid.NewGuid().ToString() + fileExtension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), newFileName);
                    fileUploadModel.Adress = path;
                    using (var fileSteam = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileSteam);
                    }
                    var fileUplodad = _mapper.Map<FileUploadModel, FileUpload>(fileUploadModel);
                    await _context.FileUpload.AddAsync(fileUplodad);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    result = true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    await _logService.LogException("SaveFile", e);

                }
            }
            return result;
        }


        public async Task<FileUploadModelImage> GetProfilePhoto(int userId)
        {
            FileUploadModelImage response = new FileUploadModelImage();

            var file = await _context.FileUpload.Where(l => l.UserId == userId).FirstOrDefaultAsync();
            if (file != null)
            {
                if (System.IO.File.Exists(file.Adress))
                {
                    response = _mapper.Map<FileUploadModelImage>(file);
                }
            }

            return response;
        }
    }
}
