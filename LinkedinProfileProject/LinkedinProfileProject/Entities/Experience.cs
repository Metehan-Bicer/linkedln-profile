using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkedinProfileProject.Entities
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Sector { get; set; }
        public string Comment { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


    }
}
