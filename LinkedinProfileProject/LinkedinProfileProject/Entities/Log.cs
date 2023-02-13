using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkedinProfileProject.Entities
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        public string Method { get; set; }

        public string Exception { get; set; }
        public DateTime ExceptionDate { get; set; }
    }
}
