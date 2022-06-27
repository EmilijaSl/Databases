using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8TemaDatabase
{
    public class BooksRepository
    {
        private readonly BooksContext _dbContext;
        public BooksRepository()
        {
            _dbContext = new BooksContext();
        }
        public void CreateCategory(Category category)
        {
            _dbContext.Categories.Add(category);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
