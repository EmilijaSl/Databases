using ManyToManyAFPersistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyAFPersistance
{
    public class BooksRepository
    {
        private readonly BookContext _dbContext;

        public BooksRepository()
        {
            _dbContext = new BookContext();
        }
        public void CreatCategory(Categories categories)
        {
            using var dbContext = new BookContext();
            _dbContext.Category.Add(categories);
            _dbContext.SaveChanges();
        }

        //public void CreateCategory(Category category)
        //{
        //    _dbContext.Categories.Add(category);
        //}
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public List<Book> GetBooksLazily(string bookNameSubstring)
        { 
        return _dbContext.Books.Where(b=>b.Name.Contains(bookNameSubstring)).ToList();
        }

    }
}
