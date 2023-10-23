using GetBooksApp.Data;
using GetBooksApp.Interfaces;
using GetBooksApp.Models;

namespace GetBooksApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public bool BookExists(int id)
        {
            return _context.BookModels.Any(p => p.Id == id);
        }

        public bool CreateBook(BookModel book)
        {
            _context.BookModels.Add(book);


            return Save();
        }

        public bool DeleteBook(BookModel id)
        {
            _context.BookModels.Remove(id);

            return Save();
        }

        public BookModel GetBook(int id)
        {
            return _context.BookModels.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<BookModel> GetBooks()
        {
            return _context.BookModels.OrderBy(x => x.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateBook(BookModel book)
        {
            _context.Update(book);
            return Save();
        }
    }
}
