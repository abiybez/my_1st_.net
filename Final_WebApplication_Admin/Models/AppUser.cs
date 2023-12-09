using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final_WebApplication_Admin.Models
{
	public class AppUser
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int UserId { get; set; }

		[Display(Name = "User Name")]
		public string UserName { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
        [Required, EmailAddress]
		public string Email { get; set; }
		public List<Training> UserTrainings { get; set; }

	}
}
