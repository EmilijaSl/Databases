using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8TemaDatabase
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Books = new List<Book>();
        }
    }
}
