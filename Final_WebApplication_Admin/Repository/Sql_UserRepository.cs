using Final_WebApplication_Admin.Models;
using System.Security.Cryptography;

namespace Final_WebApplication_Admin.Repository
{
	public class Sql_UserRepository : IUserRepository
	{
		private readonly SiteDBcontext _context;
		public Sql_UserRepository(SiteDBcontext context)
		{
			_context = context;
		}
		public AppUser addUser(AppUser user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
			return user;
		}
		public AppUser removeUser (AppUser user) 
		{
			_context.Users.Remove(user);
			_context.SaveChanges();
			return user;
		}
		public List<AppUser> getAllUser()
		{
			return _context.Users.ToList();
		}

		public AppUser getUserByEmail(string Email)
		{
			AppUser user= _context.Users.Find(Email);
			return user;
		}

		public AppUser getUserByID(int userID)
		{
			AppUser user= _context.Users.Find(userID);
			return user;
		}

		public List<Training> getUserTrainings(int userID)
		{

			List<UserTraining> UserTrainings= _context.UserTrainings.Where(x => x.UserId == userID).ToList();
			List<Training> trainings = new List<Training>();
			Sql_TrainingRepository s = new Sql_TrainingRepository(_context);
			foreach (var x in UserTrainings)
			{
				trainings.Add(s.getTrainingById(x.TrainingID));
			}

				return trainings;
		}
	}
}
