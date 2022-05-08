using Microsoft.EntityFrameworkCore;
using OnlineLibrary.BLL;
using OnlineLibrary.BLL.Models;
using OnlineLibraryASP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineLibrary.BLL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookContext _context;

        public AuthorRepository(BookContext context)
        {
            _context = context;
        }

        public List<Author> GetAll()
        {
            var authors = _context.Authors.Include(b => b.BooksWriten).ToList();
            return authors;
        }
        public void Create(Author author)
        {
           
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
        
        public Author GetById(int id)
        {
            return _context.Authors.Include(a=>a.BooksWriten).FirstOrDefault(c => c.Id == id);
        }
        public void Delete(int id)
        {
            var author = GetById(id);
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
        public void Update(Author model)
        {
            var author = GetById(model.Id);
            author.Name = model.Name;
            _context.SaveChanges();
        }
        
    }
}
    

