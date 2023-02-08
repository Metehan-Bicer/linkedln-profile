using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkedinProfileProject.Entities
{
    public class Abilities
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AbilitiesName { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


    }
}
