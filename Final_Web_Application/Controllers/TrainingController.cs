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
            foreach(Training t in a)
            {
                LoadImage(t);
            }
            return View(a);
        }
        public ViewResult Create()
        {
            return View();
        }
        public void LoadImage(Training training)
        {
            if (training.imagePath != null)
            {
                string imgPath = training.imagePath.Remove(0,1);
                string load_loc= "C:/Users/Sisay/Desktop/Images for Fidel/" + imgPath;
                FileStream file = new FileStream(load_loc, FileMode.Open);
                string serverPath = Path.Combine(webHostEnvironment.WebRootPath, imgPath);
                file.CopyTo(new FileStream(serverPath, FileMode.Create));
                training.imagePath = "/" + imgPath;

            }
            if (training.ImageUrls != null)
            {
                foreach (var timg in training.ImageUrls)
                {
                    string img = timg.url.Remove(0, 1);
                    string load_loc = "C:/Users/Sisay/Desktop/Images for Fidel/" + img;
                    FileStream file = new FileStream(load_loc, FileMode.Open);
                    string serverPath = Path.Combine(webHostEnvironment.WebRootPath, img);
                    file.CopyTo(new FileStream(serverPath, FileMode.Create));
                    timg.url = "/" + img;
                }
            }
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
