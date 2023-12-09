using Final_WebApplication_Admin.Models;

namespace Final_WebApplication_Admin.Repository
{
	public interface IUserRepository
	{
		public AppUser removeUser(AppUser user);
		public List<AppUser> getAllUser();
		public List<Training> getUserTrainings(int userID);
		public AppUser getUserByID(int userID);
		public AppUser getUserByEmail(string Email);
		public AppUser addUser(AppUser user);
	}
}
