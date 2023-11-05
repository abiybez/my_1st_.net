using Final_WebApplication_Admin.Models;
using Final_WebApplication_Admin.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Final_WebApplication_Admin.Controllers
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
                List<Training> a = _trainingRepository.getAllTraining();
                return View(a);
            }
            
            public ViewResult GetAllCategories ()
            {
                List<TrainingCategory> tc = _trainingRepository.getAllCategories();
                return View(tc);
            }
            [HttpGet]
            public ViewResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create (Training training)
            {
                if (training.trainingImage != null)
                {
                    String imgPath = "Training/Image/" + Guid.NewGuid().ToString() + "_" + training.trainingImage.FileName;
                    string serverPath = Path.Combine(webHostEnvironment.WebRootPath, imgPath);
                    string serverPath2 = Path.Combine("C:/Users/Sisay/Desktop/Images for Fidel", imgPath);
                    training.trainingImage.CopyTo(new FileStream(serverPath, FileMode.Create));
                    training.trainingImage.CopyTo(new FileStream(serverPath2, FileMode.Create));
                    //training.trainingImage = 
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
                        string serverPath2 = Path.Combine("C:/Users/Sisay/Desktop/Images for Fidel", trainingGallery.url);
                    timg.CopyTo(new FileStream(serverPath, FileMode.Create));
                    timg.CopyTo(new FileStream(serverPath2, FileMode.Create));
                    training.imagePath = "/" + trainingGallery.url;
                        training.ImageUrls.Add(trainingGallery);
                    }
                }
                Training t = _trainingRepository.addTraining(training);
            return RedirectToAction("GetAllTraining");
            }
        [HttpGet]
        public async Task<IActionResult> Remove_Training(int id)
        {
            try
            {
                Training t = _trainingRepository.getTrainingById(id);
                return View(t);
            }
            catch (Exception ex)
            {
                return RedirectToAction("GetAllTraining");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Remove_Training(Training t)
        {
            if (t != null)
            {
                _trainingRepository.removeTraining(t);
            }

            return RedirectToAction("GetAllTraining");
        }
        [HttpGet]
		public async Task<IActionResult> Remove_Categories (int id)
        {
            try
            {
                TrainingCategory tc = _trainingRepository.getCategoryByID(id);
                return View(tc);
            }
            catch (Exception ex)
            {
                return RedirectToAction("GetAllCategories");
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Remove_Categories(TrainingCategory tc)
        {
           if (tc != null)
            {
                _trainingRepository.removeTrainingCategory(tc);
            }

            return RedirectToAction("GetAllCategories");
        }

        [HttpGet]
		public ViewResult Add_Category()
		{
			return View();
		}
        [HttpPost]
        public IActionResult Add_Category(TrainingCategory tc)
        { try
            {
                TrainingCategory t = _trainingRepository.add_Category(tc);
                return RedirectToAction("GetAllCategories");
            }
            catch (Exception ex) 
            {
                return RedirectToAction("Error", ex);
            }
        }
        public IActionResult GetCategoryByID (int id)
        {
            try
            {
                TrainingCategory t = _trainingRepository.getCategoryByID(id);
                return RedirectToAction("GetAllCategories");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
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
