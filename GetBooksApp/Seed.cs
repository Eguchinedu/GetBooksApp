using GetBooksApp.Data;
using GetBooksApp.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace GetBooksApp
{
    public class Seed
    {
        private readonly DataContext _dataContext;

        public Seed(DataContext context)
        {
            _dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!_dataContext.BookModels.Any())
            {
                var books = new List<BookModel>()
                {
                new BookModel()
                {
                    Title = "Things Fall Apart",
                      Author = "Chinua Achebe"
                },
                new BookModel()
                {
                    Title =  " Women of Owu",
                      Author = "Femi Osofiasan"
                },
                new BookModel()
                {
                    Title = "The joys of motherhood",
                      Author = "Emechta Buchi"
                }
                 };
                _dataContext.BookModels.AddRange(books);
                _dataContext.SaveChanges();
            }
            if (!_dataContext.UserModels.Any())
            {
                var users = new List<UserModel>()
                {
                    new UserModel()
                    {
                        FirstName = "Egu",
                        LastName = "Chinedu",
                        UserName = "EguChinedu",
                        Password = "password",

                    },
                    new UserModel()
                    {
                        FirstName = "Zeus",
                        LastName = "egu",
                        UserName = "zeus_egu",
                        Password = "password"

                    },
                    new UserModel()
                    {
                        FirstName = "Hades",
                        LastName = "Orion",
                        UserName = "hades_orion",
                        Password = "password"

                    },
                };
                _dataContext.UserModels.AddRange(users);
                _dataContext.SaveChanges();
            }
        }
    }
}
