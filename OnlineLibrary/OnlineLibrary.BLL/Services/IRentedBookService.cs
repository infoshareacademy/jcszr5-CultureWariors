using OnlineLibrary.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Services
{
    public interface IRentedBookService
    {
        public List<RentedBook> GetAll();

        public void Rent(IEnumerable<ShoppingCart> shoppingCarts);

        public void ChangeStatus(RentedBook book);
    }
}
