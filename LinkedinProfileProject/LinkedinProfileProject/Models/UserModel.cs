using LinkedinProfileProject.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinkedinProfileProject.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Job { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string CityName { get; set; }
        public string Company { get; set; }
    }
}
