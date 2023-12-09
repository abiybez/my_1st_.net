using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_WebApplication_Admin.Models
{
    public class Training
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int tId { get; set; }
        [Display(Name = "Training Name")]
        public string tName { get; set; }
		[Display(Name = "Training Category")]
        [ForeignKey("TrainingCategory") ]
        public int tCategory {  get; set; }  
        [Display(Name = "Training Description")]
        public string tDesc { get; set; }
        [NotMapped]
        [Display(Name = "Training Image")]
        public IFormFile? trainingImage { get; set; }
        public string? imagePath { get; set; }
        [NotMapped]
        [Display(Name = " Training Gallery")]
        public IFormFileCollection? gallery { get; set; }
        public List<TrainingGallery> ImageUrls { get; set; }
		public List<AppUser> TrainingUsers{ get; set; }
        public int price { get; set; }
	}
}

