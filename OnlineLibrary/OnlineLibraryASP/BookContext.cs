using Microsoft.EntityFrameworkCore;
using OnlineLibrary.BLL.Models;

namespace OnlineLibraryASP
{
    public class BookContext : DbContext
    {

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            
        }
        public DbSet<Book>Books { get; set; }

    }
}
