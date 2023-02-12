using LinkedinProfileProject.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinkedinProfileProject.Models
{
    public class EducationModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string School { get; set; }
        public string Department { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
    }
}
