using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkedinProfileProject.Entities
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string School { get; set; }
        public string Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


    }
}
