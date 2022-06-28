using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLibrary.BLL.Enums;

namespace OnlineLibrary.BLL.Services
{
    public class RentedBookService :IRentedBookService
    { 
        
        private readonly IRentedBookRepository _rentRepository;

        public RentedBookService(IRentedBookRepository rentRepository)
        {
            _rentRepository = rentRepository;

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

        }
        public void ChangeStatus(RentedBook book)
        {
            _rentRepository.UpdateStatus(book);
        }

    }
}
