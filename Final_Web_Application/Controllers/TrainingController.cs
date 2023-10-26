using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Final_Web_Application.Models;
using Final_Web_Application.Repository;
using System.Net.NetworkInformation;

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

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Training training)
        {
            if (training.trainingImage != null)
            {
                String imgPath = "Training/Image/" + Guid.NewGuid().ToString() + "_" +
                    training.trainingImage.FileName;
                string serverPath = Path.Combine(webHostEnvironment.WebRootPath, imgPath);
                training.trainingImage.CopyTo(new FileStream(serverPath, FileMode.Create));
                training.imagePath = "/" + imgPath;
            }
            if (training.gallery != null)
            {
                training.ImageUrls = new List<TrainingGallery>();
                foreach (var timg in training.gallery)
                {
                    var trainingGallery = new TrainingGallery();
                    trainingGallery.Name = timg.Name;
                    trainingGallery.url = "Training/Gallery/" + Guid.NewGuid().ToString() +
                              "_" + timg.FileName;
                    string serverPath = Path.Combine(webHostEnvironment.WebRootPath, trainingGallery.url);
                    timg.CopyTo(new FileStream(serverPath, FileMode.Create));
                    training.imagePath = "/" + trainingGallery.url;
                    training.ImageUrls.Add(trainingGallery);
                }
            }
            Training t = _trainingRepository.addTraining(training);
            return RedirectToAction("GetAllBooks");
        }
        public ViewResult Index()
        {
            var training = _trainingRepository.getAllTraining();
            return View(training);
        }

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
