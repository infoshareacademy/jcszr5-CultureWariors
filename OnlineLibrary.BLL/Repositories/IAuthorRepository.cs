using OnlineLibrary.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Repositories
{
    public interface IAuthorRepository
    {
        public List<Author> GetAll();
        public void Create(Author author);
        
        public Author GetById(int id);
        public void Delete(int id);
        public void Update(Author model);
    }
}
