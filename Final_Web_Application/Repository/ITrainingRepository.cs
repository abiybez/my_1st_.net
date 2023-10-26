using Final_Web_Application.Models;
namespace Final_Web_Application.Repository
{
    public interface ITrainingRepository
    {
        public List<Training> getAllTraining();
        public Training getTrainingById(int tId);
        public Training getTrainingByName(string Name);
        public Training addTraining(Training training);
    }
}