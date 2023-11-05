using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Final_Web_Application.Models;
using Final_Web_Application.Repository;
using System.Net.NetworkInformation;
using static System.Net.Mime.MediaTypeNames;

namespace Final_Web_Application.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

		public TrainingController(ITrainingRepository trainingRepository, IWebHostEnvironment webHostEnvironment)
        {
            this._trainingRepository = trainingRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
		public ViewResult GetAllTraining()
        {
            List <Training> a = _trainingRepository.getAllTraining();
            return View(a);
        }
        public ViewResult Create()
        {
            return View();
        }
        //public ViewResult Index()
        //{
        //    var training = _trainingRepository.getAllTraining();
        //    return View(training);
        //}
        public ViewResult Index()
        { return View(); }

        public ViewResult GetTrainingById(int id)
        {
            Training t = _trainingRepository.getTrainingById(id);
            return View(t);
        }
        public ViewResult GetTrainingByName(string name)
        {
            Training t = _trainingRepository.getTrainingByName(name);
            return View(t);
        }
    }
}
