using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Repositories
{
    public class UserRepository:IUserRepository
    {
        
        
        public static int UserCounter = 4;
        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Id = 1,
                Login = "Bartek",
                Password = "12345",

            },
            new User()
            {
                Id = 2,
                Login = "Krzysiek",
                Password="12345",

            },
            new User()
            {
                Id = 3,
                Login = "Ewelina",
                Password="12345",
            },
            new User()
            {
                Id = 4,
                Login = "Piotr",
                Password="12345",
                Rented = new List<BookRent> { new BookRent()
                {
                    Id=1,
                    Title="123",
                    Author = "123",
                    BookType = Enums.BookType.Dramat,
                    PublicationDate = 1800,
                } }
              
            },
        };

        public List<User> GetAll()
        {
            return Users;
        }

        public void Create(User user)
        {
            user.Id = GetNextId();
            Users.Add(user);
        }

        public int GetNextId()
        {
            UserCounter += 1;
            return UserCounter;
        }

        public User GetById(int id)
        {
            return Users.FirstOrDefault(u => u.Id == id);
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            Users.Remove(user);
        }

        public void Update(User model)
        {
            var user = GetById(model.Id);
            user.Login = model.Login;
            user.Password = model.Password;
            user.Rented = model.Rented;
            user.History = model.History;
        }
    }
}
