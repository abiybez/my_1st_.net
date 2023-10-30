using Final_Web_Application.Models;

namespace Final_Web_Application.Repository
{
	public interface IUserRepository
	{
		public List<AppUser> getAllUser();
		public List<Training> getUserTrainings(int userID);
		public AppUser getUserByID(int userID);
		public AppUser getUserByEmail(string Email);
		public AppUser addUser(AppUser user);
	}
}
