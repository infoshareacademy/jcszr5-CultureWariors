using Microsoft.EntityFrameworkCore;
using OnlineLibrary.BLL.Enums;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Services;
using OnlineLibraryASP;

namespace OnlineLibrary.BLL.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly BookContext _context;

        
        public ShoppingCartRepository(BookContext db)
        {
            _context = db;
            
        }
        public List<ShoppingCart> GetAll()
        {

            var carts = _context.ShoppingCart.Include(b=>b.Book)
                .Include(b=>b.ApplicationUser)
                .Include(b=>b.Book.Author)
                .ToList();
            
            return carts;
        }
        public void Create(ShoppingCart cart)
        {
            _context.Add(cart);
            
            _context.SaveChanges();
        }
        
        public ShoppingCart GetById(int id)
        {
            return _context.ShoppingCart.FirstOrDefault(c => c.ShoppingCartId == id);
        }
        public void Delete(int id)
        {
            var shoppingCart = GetById(id);
            _context.ShoppingCart.Remove(shoppingCart);
            _context.SaveChanges();
        }
        public void ClearCart(IEnumerable<ShoppingCart> cart)
        {
            foreach (var cartItem in cart)
            {
                _context.ShoppingCart.Remove(cartItem);
                _context.SaveChanges();
            }
        }
    }
}
