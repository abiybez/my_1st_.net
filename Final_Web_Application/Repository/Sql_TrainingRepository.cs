using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
        public UserTraining addUserTraining(UserTraining ut)
        {
            _context.UserTrainings.Add(ut);
            _context.SaveChanges();
            return ut;
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

        public List<Training> getTrainingByName(string Name)
        {
            List < Training > t = _context.trainings.Where(x => x.tName == Name).ToList();
            return t;
        }
        int count = 0;
        public int getTrainingCount()
        {
            count++;
            return count;
        }
    }
}

