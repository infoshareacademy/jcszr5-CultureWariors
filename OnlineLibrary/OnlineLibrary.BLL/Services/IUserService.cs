using OnlineLibrary.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Services
{
    public interface IUserService
    {
        public List<User> GetAll();
        public User GetById(int id);
        public void Create(User book);
        public void Update(User model);
        public void Delete(int id);
        public void RentABook(BookRent book, User user);
        public void ReturnABook(User user, BookRent book);
    }
}
