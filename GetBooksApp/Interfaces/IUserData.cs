using GetBooksApp.Models;

namespace GetBooksApp.Interfaces
{
    public interface IUserData
    {
        ICollection<UserModel> GetUsers();

        UserModel GetUser(int id);


        bool AddUser(UserModel user);

        bool Save();
    }
}
