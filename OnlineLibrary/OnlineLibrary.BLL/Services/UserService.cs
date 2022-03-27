using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(User user)
        {
            _userRepository.Create(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Update(User model)
        {
            _userRepository.Update(model);
        }
        public void RentABook(BookRent book,User user)
        {
            user.Rented.Add(book);
        }
        public void ReturnABook(User user, BookRent book)
        {
            user.Rented.Remove(book);
            user.History.Add(book);
        }
    }
}
