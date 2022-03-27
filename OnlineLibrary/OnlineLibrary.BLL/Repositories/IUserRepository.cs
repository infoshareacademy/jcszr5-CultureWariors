using OnlineLibrary.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public void Create(User user);
        public int GetNextId();
        public User GetById(int id);
        public void Delete(int id);
        public void Update(User model);
    }
}
