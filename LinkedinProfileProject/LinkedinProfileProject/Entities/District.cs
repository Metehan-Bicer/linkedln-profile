using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkedinProfileProject.Entities
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        public int CityId { get; set; }
        public string DistrictName { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}
