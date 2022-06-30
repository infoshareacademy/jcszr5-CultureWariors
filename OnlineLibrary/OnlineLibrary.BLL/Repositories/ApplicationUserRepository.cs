using Microsoft.EntityFrameworkCore;
using OnlineLibrary.BLL.Enums;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Services;
using OnlineLibraryASP;

namespace OnlineLibrary.BLL.Repositories
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly BookContext _context;

        public ApplicationUserRepository(BookContext db) : base(db)
        {
            _context = db;
        }

        public List<ApplicationUser> GetAll()
        {
            var users = _context.ApplicationUsers.ToList();

            return users;
        }
        public void Create(ApplicationUser user)
        {
            _context.Add(user);

            _context.SaveChanges();
        }

       

     
    }
}
