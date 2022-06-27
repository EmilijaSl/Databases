using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyAFPersistance.Models
{
    public class Book 
    {
        //[DefaultValue("newid()")] //random id funkcija i SQL paduoda vis nauja guida ilga ID
        
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public virtual List<Categories> Category { get; private set; }
        public Book(string name)
        {
            Id = Guid.NewGuid();
            Name= name;
            Category = new List<Categories>();
        }
    }
}
