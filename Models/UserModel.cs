using Google.Apis.Admin.Directory.directory_v1.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace trainingproject.Models
{
    public class UserModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; } 

        [Required]
   
        public string Mobile { get; set; } 

        [Required]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; } 

        [Required]
        public DateTime Dob { get; set; }

        [Required]
        public string Hobbies { get; set; } 

        [Required]
        public IFormFile Profilepic { get; set; } 

      
    }
}
