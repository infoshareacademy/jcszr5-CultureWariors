using Microsoft.EntityFrameworkCore;
using OnlineLibrary.BLL.Enums;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Services;
using OnlineLibraryASP;

namespace OnlineLibrary.BLL.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly BookContext _context;

        
        public ShoppingCartRepository(BookContext db) :base(db)
        {
            _context = db;
            
        }
        public List<ShoppingCart> GetAll()
        {
            var carts = _context.ShoppingCart.ToList();
            
            return carts;
        }
        public void Create(ShoppingCart cart)
        {
            _context.Add(cart);
            
            _context.SaveChanges();
        }
        
        public ShoppingCart GetById(int id)
        {
            return _context.ShoppingCart.FirstOrDefault(c => c.Id == id);
        }
        public void Delete(int id)
        {
            var book = GetById(id);
            _context.ShoppingCart.Remove(book);
            _context.SaveChanges();
        }
        
    }
}
