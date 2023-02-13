using LinkedinProfileProject.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinkedinProfileProject.Models
{
    public class FileUploadModel
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
        public string Adress { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public int UserId { get; set; }
    }
    public class FileUploadModelImage
    {
        public int Id { get; set; }
        public string Base64 { get; set; }
        public string Adress { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public int UserId { get; set; }
    }
}
