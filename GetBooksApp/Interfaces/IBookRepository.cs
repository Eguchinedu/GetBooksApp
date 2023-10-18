using GetBooksApp.Models;

namespace GetBooksApp.Interfaces
{
    public interface IBookRepository
    {
        ICollection<BookModel> GetBooks();
        BookModel GetBook(int id);

        bool BookExists(int id);

        bool CreateBook(BookModel book);

        bool UpdateBook(BookModel book); 
        
        bool DeleteBook(BookModel id);

        bool Save();
    }
}
