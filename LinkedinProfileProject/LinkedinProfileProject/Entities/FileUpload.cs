using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkedinProfileProject.Entities
{
    public class FileUpload
    {
        [Key]
        public int Id { get; set; }
        public string Adress { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
