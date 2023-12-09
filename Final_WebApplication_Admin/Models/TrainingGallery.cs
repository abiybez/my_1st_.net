using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final_WebApplication_Admin.Models
{
    public class TrainingGallery
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int Id { get; set; }
        public string Name { get; set; }
        public string url { get; set; }
        public int trainingID { get; set; }
    }
}

