using Final_Web_Application.Models;
using Final_Web_Application.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Final_Web_Application.Controllers
{
	public class UserController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
		private readonly IUserRepository _userRepository;
		public UserController(IUserRepository userRepository, IWebHostEnvironment webHostEnvironment)
		{
			this._userRepository = userRepository;
			this.webHostEnvironment = webHostEnvironment;
		}
		public ViewResult Index()
		{
            ViewBag.user = IState.Logged_In_User;
            return View();
		}

		public ViewResult GetUserByEmail(string email)
		{
			AppUser user = _userRepository.getUserByEmail(email);
			return View(user);
		}
		[HttpGet]
		public ViewResult AddUser() { return View(); }
		[HttpPost]
		public IActionResult AddUser (AppUser user)
		{
            try {
                var emailAddress = new MailAddress(user.Email);
                if (_userRepository.getUserByEmail(user.Email) == null)
                {
                    if (_userRepository.getUserByUserName(user.UserName) == null)
                    {
                        if (user.Password == user.cPwd)
                        {
                            IState.Logged_In_User = _userRepository.addUser(user);
                            List<Training> t = _userRepository.getUserTrainings(IState.Logged_In_User.UserId);
                            if (t.Count != 0)
                            {
                                IState.Logged_In_User.does_user_have_training = true;
                                IState.Logged_In_User.UserTrainings = t;
                            }
                            else
                            {
                                IState.Logged_In_User.does_user_have_training = false;
                            }
                            return RedirectToAction("Index");
                        }
                        else return RedirectToAction();
                    }
                    else return RedirectToAction();
                }
                else
                {
                    return RedirectToAction();
                }
            }
            catch {
                return RedirectToAction();
            }
		}
        [HttpGet]
        public ViewResult Login_User() { return View(); }
        [HttpPost]
        public IActionResult Login_User(AppUser user)
        {
			AppUser user2 = _userRepository.getUserByEmail(user.Email);
			if(user2 != null)
			{
                if (user.UserName == user2.UserName)
                {
                    if (user.Password == user2.Password)
                    {
                            List<Training> t = _userRepository.getUserTrainings(user2.UserId);
                            if (t.Count != 0)
                            {
                                user2.does_user_have_training = true;
                                user2.UserTrainings = t;
                            }
                            else {
                                user2.does_user_have_training = false;
                            }
                        IState.Logged_In_User = user2;
                        return RedirectToAction("Index");
                    }
                    else return RedirectToAction();
                }
                else
                {
                    return RedirectToAction();
                }
            }
			else
			{
                Console.WriteLine("-");
                Console.WriteLine("User Not found");
                Console.WriteLine("-");
                return RedirectToAction();
            }
        }

        public ViewResult Contact_Us()
        {
            ViewBag.user = IState.Logged_In_User;
            return View(); 
        }
        public ViewResult About_Us() 
        {
            ViewBag.user = IState.Logged_In_User;
            return View();
        }

            //GetAllTraining
        //public List<AppUser> getAllUser();
        //public List<Training> getUserTrainings(int userID);
        //public AppUser getUserByID(int userID);
        //public AppUser getUserByEmail(string Email);
        //public AppUser addUser(AppUser user);
    }
}
