using Final_Web_Application.Models;
using Final_Web_Application.Repository;
using Microsoft.AspNetCore.Mvc;

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
		public ViewResult GetAllUsers()
		{
			List<AppUser> a = _userRepository.getAllUser();
			return View(a);
		}
		public IActionResult Index(AppUser user)
		{
			user.UserTrainings =  _userRepository.getUserTrainings(user.UserId);
			return View(user);
		}
		public ViewResult GetUserByID(int uid)
		{
			AppUser user = _userRepository.getUserByID(uid);
			return View(user);
		}
		public ViewResult GetUserByEmail(string email)
		{
			AppUser user = _userRepository.getUserByEmail(email);
			return View(user);
		}
		public IActionResult AddUser (AppUser user)
		{
			AppUser user1 = _userRepository.addUser(user);
			return Index(user1);
		}

		//public List<AppUser> getAllUser();
		//public List<Training> getUserTrainings(int userID);
		//public AppUser getUserByID(int userID);
		//public AppUser getUserByEmail(string Email);
		//public AppUser addUser(AppUser user);
	}
}
