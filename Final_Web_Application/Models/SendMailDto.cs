using System.ComponentModel.DataAnnotations;

namespace Final_Web_Application.Models
{
    public class SendMailDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
