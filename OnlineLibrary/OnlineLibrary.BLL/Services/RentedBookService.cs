using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLibrary.BLL.Enums;
using System.Security.Claims;

namespace OnlineLibrary.BLL.Services
{
    public class RentedBookService : IRentedBookService
    {

        private readonly IRentedBookRepository _rentRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public RentedBookService(IRentedBookRepository rentRepository, IShoppingCartRepository shoppingCartRepository)
        {
            _rentRepository = rentRepository;
            _shoppingCartRepository = shoppingCartRepository;

        }

        public RentedBook GetById(int id)
        {
            return _rentRepository.GetById(id);
        }
        public List<RentedBook> GetAll()
        {
            return _rentRepository.GetAll();
        }

        public void Rent(IEnumerable<ShoppingCart> shoppingCarts)
        {
            foreach (var cart in shoppingCarts)
            {
                var book = new RentedBook
                {
                    BookId = cart.BookId,
                    ApplicationUserId = cart.ApplicationUserId,
                    Status = BookStatus.Processing
                };

                _rentRepository.Create(book);
                
            }
            _shoppingCartRepository.ClearCart(shoppingCarts);

        }
        public void ReadyBooks(RentedBook book)
        {
            _rentRepository.ToRelasing(book);
        }
        public void RentingBooks(RentedBook book)
        {
            _rentRepository.ToRenting(book);
        }
        public void ReturningBooks(RentedBook book)
        {
            _rentRepository.ToReturnig(book);

        }

    }
}
