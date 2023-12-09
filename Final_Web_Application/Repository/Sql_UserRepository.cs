using Final_Web_Application.Models;
using System.Security.Cryptography;

namespace Final_Web_Application.Repository
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

		public List<AppUser> getAllUser()
		{
			return _context.Users.ToList();
		}

		public AppUser getUserByEmail(string Email)
		{
			try
			{
                AppUser user = _context.Users.First(x => x.Email == Email);
				return user;
			}
			catch
			{
				return null;
			}
		}
        public AppUser getUserByUserName(string uName)
        {
			try
			{
                AppUser user = _context.Users.First(x => x.UserName == uName);
                return user;
            }
			catch (Exception ex)
			{
				return null;
			}
        }
        public AppUser getUserByID(int userID)
		{
			AppUser user= _context.Users.Find(userID);
			return user;
		}

		public List<Training> getUserTrainings(int userID)
		{
			try
			{
				List<UserTraining> UserTrainings = _context.UserTrainings.Where(x => x.UserId == userID).ToList();
				List<Training> trainings = new List<Training>();
				Sql_TrainingRepository s = new Sql_TrainingRepository(_context);
				foreach (var x in UserTrainings)
				{
					trainings.Add(s.getTrainingById(x.TrainingID));
				}

				return trainings;

			}
			catch(Exception ex) {
				return null;
			}
		}	
	}
}
