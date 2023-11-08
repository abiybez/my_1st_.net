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
        AppUser Loged_In_User = null;
        private readonly IWebHostEnvironment webHostEnvironment;
		private readonly IUserRepository _userRepository;
		public UserController(IUserRepository userRepository, IWebHostEnvironment webHostEnvironment)
		{
			this._userRepository = userRepository;
			this.webHostEnvironment = webHostEnvironment;
		}
		public ViewResult GetAllUsers()
		{
			List<AppUser> a = _userRepository.getAllUser();
			return View(a);
		}
		public ViewResult Index(AppUser user)
		{
			return View(user);
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
			if (_userRepository.getUserByEmail(user.Email) == null)
			{
				if (_userRepository.getUserByUserName(user.UserName) == null)
				{
					if(user.Password==user.cPwd){
                        Loged_In_User = _userRepository.addUser(user);
                        List<Training> t = _userRepository.getUserTrainings(Loged_In_User.UserId);
                        if (t != null)
                        {
                            Loged_In_User.does_user_have_training = true;
                            Loged_In_User.UserTrainings = t;
                        }
                        else
                        {
                            Loged_In_User.does_user_have_training = false;
                        }
                        ViewBag.user = Loged_In_User ;
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
						try {
                            List<Training> t = _userRepository.getUserTrainings(Loged_In_User.UserId);
                            user2.does_user_have_training = true;
                            user2.UserTrainings = t;
                        }
						catch(Exception ex)
						{
							user2.does_user_have_training = false;
						}
                        return Index(user2);
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

        //public List<AppUser> getAllUser();
        //public List<Training> getUserTrainings(int userID);
        //public AppUser getUserByID(int userID);
        //public AppUser getUserByEmail(string Email);
        //public AppUser addUser(AppUser user);
    }
}
