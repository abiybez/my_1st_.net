using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final_Web_Application.Models
{
	public class UserTraining
	{

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int Id { get; set; }
		[ForeignKey("AppUser")]
		public int UserId { get; set; }
		[ForeignKey("Training")]
		public int TrainingID { get; set; }
	}
}
