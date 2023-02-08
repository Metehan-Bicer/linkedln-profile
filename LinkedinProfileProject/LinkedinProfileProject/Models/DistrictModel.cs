using LinkedinProfileProject.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinkedinProfileProject.Models
{
    public class DistrictModel
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string DistrictName { get; set; }
        public string CityName { get; set; }
    }
}
