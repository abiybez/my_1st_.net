using Final_WebApplication_Admin.Models;

namespace Final_WebApplication_Admin.Repository
{
    public interface ITrainingRepository
    {
        public TrainingCategory getCategoryByID(int id);
        public Training removeTraining(Training training);
        public void removeTrainingCategory(TrainingCategory tc);
		public List<TrainingCategory> getAllCategories();
        public TrainingCategory add_Category(TrainingCategory tc);
        public List<Training> getAllTraining();
        public Training getTrainingById(int tId);
        public Training getTrainingByName(string Name);
        public Training addTraining(Training training);
        
    }
}

