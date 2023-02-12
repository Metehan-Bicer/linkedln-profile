using LinkedinProfileProject.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinkedinProfileProject.Models
{
    public class ExperienceModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Sector { get; set; }
        public string Comment { get; set; }
    }
}
