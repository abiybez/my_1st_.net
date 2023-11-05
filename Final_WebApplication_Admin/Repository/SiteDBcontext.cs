using Microsoft.EntityFrameworkCore;
using Final_WebApplication_Admin.Models;
using System.Data;
using System.Collections.Generic;

namespace Final_WebApplication_Admin.Repository
{
    public class SiteDBcontext : DbContext
    {
        public SiteDBcontext(){ }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.; database = SiteDB; 
			integrated security = true; TrustServerCertificate = True;");
        }
        public DbSet<Training> trainings { get; set; }
        public DbSet<TrainingGallery> trainingGalleries { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<TrainingCategory> category { get; set; }
        public DbSet<UserTraining> UserTrainings { get; set; }
    }
}
