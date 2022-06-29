using OnlineLibrary.BLL.Models;

namespace OnlineLibrary.BLL.Repositories
{
    public interface IShoppingCartRepository 
    {
        public List<ShoppingCart> GetAll();
        public void Create(ShoppingCart cart);
        public ShoppingCart GetById(int id);
        public void Delete(int id);

        public void ClearCart(IEnumerable<ShoppingCart> cart);
    }
}