using GetBooksApp.Data;
using GetBooksApp.Interfaces;
using GetBooksApp.Models;

namespace GetBooksApp.Repository
{
    public class UserData : IUserData
    {
        private readonly DataContext _context;

        public UserData(DataContext context)
        {
            _context = context;

        }
        public bool AddUser(UserModel user)
        {
            _context.UserModels.Add(user);

            return Save();
        }

        public UserModel GetUser(int id)
        {
            return _context.UserModels.Where(p => p.UserId == id).FirstOrDefault();
        }

        public ICollection<UserModel> GetUsers()
        {
            return _context.UserModels.OrderBy(x => x.UserId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
