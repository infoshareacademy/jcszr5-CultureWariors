using OnlineLibrary.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Repositories
{
    public class AuthorRepository
    {
        
        private static int AuthorCounter;
        private static List<Author> Authors = new List<Author>
        {
            new Author
            {
                Id = 1,
                Name = "Andrzej",
                Surname = "Sapkowski",
            },
            new Author
            {
                Id = 2,
                Name = "Bolesław",
                Surname = "Prus",
                
            },
            new Author
            {
                Id = 3,
                Name = "John Ronald Reuel",
                Surname = "Tolkien",
                
    }

        };
        public List<Author> GetAll()
        {
            return Authors;
        }
        public void Create(Author author)
        {
           author.Id = GetNextId();
            Authors.Add(author);
        }
        public int GetNextId()
        {
            AuthorCounter += 1;
            return AuthorCounter;
        }
        public Author GetById(int id)
        {
            return Authors.FirstOrDefault(c => c.Id == id);
        }
        public void Delete(int id)
        {
            var author = GetById(id);
            Authors.Remove(author);
        }
        public void Update(Author model)
        {
            var book = GetById(model.Id);
            book.Name = model.Name;
            book.Surname = model.Surname;
            

        }
    }
}
    

