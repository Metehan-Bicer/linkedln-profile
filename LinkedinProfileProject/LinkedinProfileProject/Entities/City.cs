using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinkedinProfileProject.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
    }
}
