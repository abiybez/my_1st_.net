using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final_Web_Application.Models
{
	public class AppUser
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int UserId { get; set; }
		[NotMapped]
		public bool does_user_have_training { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
		[NotMapped]
        public string cPwd{ get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
		public List<Training> UserTrainings { get; set; }

	}
}
