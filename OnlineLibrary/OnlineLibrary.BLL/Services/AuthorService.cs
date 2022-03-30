using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }
        public Author GetById(int id)
        {
            return _authorRepository.GetById(id);
        }
        public void Create(Author author)
        {
            _authorRepository.Create(author);
        }
        public void Update(Author model)
        {
            _authorRepository.Update(model);
        }
        public void Delete(int id)
        {
            _authorRepository.Delete(id);
        }
        

       
    }
}
