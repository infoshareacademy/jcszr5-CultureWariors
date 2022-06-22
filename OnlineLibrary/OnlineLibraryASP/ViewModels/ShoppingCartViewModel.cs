using OnlineLibrary.BLL.Models;

namespace OnlineLibraryASP.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCart> CartList { get; set; }
    }
}
