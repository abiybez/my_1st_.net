using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Final_Web_Application.Models;
using Final_Web_Application.Repository;
using System.Net.NetworkInformation;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Mail;
using System.Net;

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
        [HttpGet]
        public ViewResult Contact_Us()
        {
            ViewBag.user = IState.Logged_In_User;
            return View();
        }
        [HttpPost]
        public IActionResult ContactUs(SendMailDto sendMailDto)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                MailMessage mail = new MailMessage();
                // you need to enter your mail address
                mail.From = new MailAddress("abiybata@gmail.com");

                //To Email Address - your need to enter your to email address
                mail.To.Add("abiybata@gmail.com");

                mail.Subject = sendMailDto.Subject;

                //you can specify also CC and BCC - i will skip this
                //mail.CC.Add("");
                //mail.Bcc.Add("");

                mail.IsBodyHtml = true;

                string content = "Name : " + sendMailDto.Name;
                content += "<br/> Message : " + sendMailDto.Message;

                mail.Body = content;


                //create SMTP instant

                //you need to pass mail server address and you can also specify the port number if you required
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                //Create nerwork credential and you need to give from email address and password
                NetworkCredential networkCredential = new NetworkCredential("abiybata@gmail.com", "yiwz ukcx bwai iuia");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587; // this is default port number - you can also change this
                smtpClient.EnableSsl = true; // if ssl required you need to enable it
                smtpClient.Send(mail);


                ViewBag.Message = "Mail Send";

                // now i need to create the from 
                ModelState.Clear();

            }
            catch (Exception ex)
            {
                //If any error occured it will show
                ViewBag.Message = ex.Message.ToString();
            }
            return View();
        }
        public ViewResult About_Us()
        {
            ViewBag.user = IState.Logged_In_User; 
            return View();
        }
        public ViewResult GetAllTraining()
        {
            ViewBag.user = IState.Logged_In_User; 
            List <Training> a = _trainingRepository.getAllTraining();
            for (int i = 0; i< a.Count;i++)
            {
                LoadImage(a[i]);
                a[i].img_loaded = true;
                //a[i].Gallery_loaded = true;
            }
            return View(a);
        }
        public void LoadImage(Training training)
        {
            if (training.imagePath != null)
            {
                if(training.img_loaded  ==  false)
                {
                    string imgPath = training.imagePath.Remove(0, 1);
                    string load_loc = "C:/Users/Sisay/Desktop/Images for Fidel/" + imgPath;
                    FileStream file = new FileStream(load_loc, FileMode.Open);
                    string serverPath = Path.Combine(webHostEnvironment.WebRootPath, imgPath);
                    FileStream file2 = new FileStream(serverPath, FileMode.Create);
                    file.CopyTo(file2);
                    file2.Close();
                    file.Close();
                    training.imagePath = "/" + imgPath;
                }

            }
        }
        public void LoadGallery(Training training) 
        {
            if (training.ImageUrls != null)
            {
                if (training.Gallery_loaded == false)
                {
                    for (int i = 0; i< training.ImageUrls.Count; i++)
                    {
                        string img = training.ImageUrls[i].url;//.Remove(0, 1);
                        string load_loc = "C:/Users/Sisay/Desktop/Images for Fidel/" + img;
                        FileStream file = new FileStream(load_loc, FileMode.Open);
                        string serverPath = Path.Combine(webHostEnvironment.WebRootPath, img);
                        FileStream file2 = new FileStream(serverPath, FileMode.Create);
                        file.CopyTo(file2);
                        file2.Close();
                        file.Close();
                        training.ImageUrls[i].url = "/" + img;
                    }
                    training.Gallery_loaded = true;
                }
            }
        }

        //public ViewResult Index()
        //{
        //    var training = _trainingRepository.getAllTraining();
        //    return View(training);
        //}
        public ViewResult Index()
        { 
            return View(); 
        }
        public IActionResult Buy_course(int id)
        {
            UserTraining ut = new UserTraining();
            ut.UserId = IState.Logged_In_User.UserId;
            ut.TrainingID = id;
             IState.Logged_In_User.UserTrainings.Add(_trainingRepository.getTrainingById(_trainingRepository.addUserTraining(ut).TrainingID));
            IState.Logged_In_User.does_user_have_training = true;
            return RedirectToAction("GetAllTraining");
        }
        public ViewResult GetTrainingById(int id)
        {
            ViewBag.user = IState.Logged_In_User;
            Training t = _trainingRepository.getTrainingById(id);
            LoadGallery(t);
            return View(t);
        }
        public ViewResult GetTrainingByName(String SearchString)
        {
            List<Training> t = _trainingRepository.getTrainingByName(SearchString);
            return View(t);
        }
        public IActionResult Logout_user() {
            IState.Logged_In_User = null;
            return RedirectToAction("Index");    
        }
    }
}
