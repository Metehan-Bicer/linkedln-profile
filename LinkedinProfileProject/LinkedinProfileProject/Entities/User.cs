using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkedinProfileProject.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Job { get; set; }
        public int DistrictId { get; set; }
        public string Company { get; set; }
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }


    }
}
