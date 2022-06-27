using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyAFPersistance.Models
{
    public class Categories
    {
        
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public virtual List<Book> Books { get; private set; }
        public Categories(string name)
        { 
            Id = Guid.NewGuid();
            Name = name;
            Books = new List<Book>();
        }
    }
}
