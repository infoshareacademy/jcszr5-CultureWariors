using Microsoft.EntityFrameworkCore;
using OnlineLibraryASP.Models;

namespace OnlineLibraryASP
{
    public class BookContext : DbContext
    {
        private readonly bool _useLazyLoading;

        public BookContext()
        {
                
        }

        public BookContext(bool useLazyLoading)
        {
            _useLazyLoading = useLazyLoading;
        }
        public DbSet<Book>Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (_useLazyLoading)
            {
                //optionsBuilder.UseLazyLoadingProxies();
            }

            optionsBuilder
                .UseSqlServer("Server=localhost;Database=BooksDb;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }
    }
}
