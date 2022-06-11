using OnlineLibrary.BLL.Models;

namespace OnlineLibrary.BLL.Repositories
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        public List<ShoppingCart> GetAll();
        public void Create(ShoppingCart cart);
        public ShoppingCart GetById(int id);
        public void Delete(int id);

    }
}