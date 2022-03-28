using OnlineLibrary.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Services
{
    public interface IAuthorService
    {
        public List<Author> GetAll();
        public Author GetById(int id);
        public void Create(Author author);
        public void Update(Author model);
        public void Delete(int id);
       
    }
}
