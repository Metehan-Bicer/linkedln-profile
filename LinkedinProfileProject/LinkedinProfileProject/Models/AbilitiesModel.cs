using LinkedinProfileProject.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinkedinProfileProject.Models
{
    public class AbilitiesModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AbilitiesName { get; set; }
    }
}
