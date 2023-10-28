﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final_Web_Application.Models
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
		public string Email { get; set; }
		public List<UserTraining> TrainingUsers { get; set; }

	}
}
