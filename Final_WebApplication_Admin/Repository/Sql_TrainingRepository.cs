using System.Linq;
using System.Net;
using Final_WebApplication_Admin.Models;
using Final_WebApplication_Admin.Repository;
using Microsoft.EntityFrameworkCore;

namespace Final_WebApplication_Admin.Repository
{
    public class Sql_TrainingRepository : ITrainingRepository
    {
        private readonly SiteDBcontext _context;

        public Sql_TrainingRepository(SiteDBcontext context)
        {
            _context = context;
        }
        public Training addTraining(Training training)
        {
            _context.trainings.Add(training);
            _context.SaveChanges();
            return training;
        }
        public Training removeTraining(Training training) 
        {
            _context.trainings.Remove(training);
			_context.SaveChanges(); 
            return training;
		}
		public void removeTrainingCategory(TrainingCategory tc)
        {
            try {
                _context.category.Remove(tc);
                _context.SaveChanges();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
		}
		public TrainingCategory add_Category(TrainingCategory tc)
        {
            _context.category.Add(tc);
            _context.SaveChanges();
            return tc;
        }
        public List<TrainingCategory> getAllCategories()
        {
            return _context.category.ToList();
        }
        public TrainingCategory getCategoryByID(int id) 
        {
            return _context.category.Find(id);
        }
        public List<Training> getAllTraining()
        {
            return _context.trainings.ToList();
        }

        public Training getTrainingById(int tId)
        {
            Training training = _context.trainings.Find(tId);
            training.ImageUrls = _context.trainingGalleries.Where(x => x.trainingID == tId).ToList();

                return training; 
        }

        public Training getTrainingByName(string Name)
        {
            return _context.trainings.Find(Name);
        }
        int count = 0;
        public int getTrainingCount()
        {
            count++;
            return count;
        }
    }
}

