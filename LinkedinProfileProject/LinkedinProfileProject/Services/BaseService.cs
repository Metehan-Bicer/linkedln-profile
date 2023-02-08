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
        public BaseService(IMapper mapper, LinkedlnProfileContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<CityModel>> GetCity()
        {
            List<CityModel> cityModel = new List<CityModel>();
            cityModel = await _mapper.ProjectTo<CityModel>(_context.City).ToListAsync();
            // todo mete her metoda try catch eklenecek log yapısı ekle
            return cityModel;
        }
        public async Task<List<DistrictModel>> GetDistrictByCityId(int cityId)
        {
            List<DistrictModel> districtModel = new List<DistrictModel>();
            districtModel = await _mapper.ProjectTo<DistrictModel>(_context.District.Where(x=>x.CityId == cityId).Include(x=>x.City)).ToListAsync();
            // todo mete her metoda try catch eklenecek log yapısı ekle

            return districtModel;
        }
    }
}
