using Final_Web_Application.Models;

namespace Final_Web_Application.Controllers
{
    public interface IState
    {
        public static AppUser Logged_In_User {  get; set; }
    }
}
