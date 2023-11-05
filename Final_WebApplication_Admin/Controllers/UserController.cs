using Final_WebApplication_Admin.Models;
using Final_WebApplication_Admin.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Final_WebApplication_Admin.Controllers
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
        [HttpGet]
        public async Task<IActionResult> Remove_User(int id)
        {
            try
            {
				AppUser au = _userRepository.getUserByID(id); 
                return View(au);
            }
            catch (Exception ex)
            {
                return RedirectToAction("GetAllUsers");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Remove_User(AppUser au)
        {
            if (au != null)
            {
                _userRepository.removeUser(au);
            }

            return RedirectToAction("GetAllUsers");
        }
        [HttpGet]
		public ViewResult AddUser()
		{
			return View();
		}

        public IActionResult AddUser (AppUser user)
		{
			_userRepository.addUser(user);
			return RedirectToAction("GetAllUsers");

        }

		//public List<AppUser> getAllUser();
		//public List<Training> getUserTrainings(int userID);
		//public AppUser getUserByID(int userID);
		//public AppUser getUserByEmail(string Email);
		//public AppUser addUser(AppUser user);
	}
}
