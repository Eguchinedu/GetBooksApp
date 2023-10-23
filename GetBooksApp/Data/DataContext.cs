using GetBooksApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GetBooksApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {
            
        }

        public DbSet<BookModel> BookModels { get; set; }

        public DbSet<UserModel> UserModels { get; set; }

    }
}
