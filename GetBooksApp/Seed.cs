using GetBooksApp.Data;
using GetBooksApp.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace GetBooksApp
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.BookModels.Any())
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
                dataContext.BookModels.AddRange(books);
                dataContext.SaveChanges();
            }
        }
    }
}
