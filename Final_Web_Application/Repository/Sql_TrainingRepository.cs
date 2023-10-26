using System.Linq;
using System.Net;
using Final_Web_Application.Models;
using Final_Web_Application.Repository;

namespace Final_Web_Application.Repository
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

