using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final_WebApplication_Admin.Models
{
	public class TrainingCategory
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int CategoryID { get; set; }

		[Display(Name = "Category Name")]
		public string Category_Name { get; set; }
		public List<Training> Trainings { get; set; }
		

	}
}
