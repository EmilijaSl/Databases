using ManyToManyAFPersistance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyAFPersistance
{
    public class BookContext :  DbContext //sitaas DbContext prisideda per nugget pckg. viskas kas aprasyta sioje klaseje bus lentelese
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Categories> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer($"Server=localhost;Database=ManyToMany;Trusted_Connection=True;");
      //tos dvi eilutes virs nurodo C# kaip pasiekt duomenu baze ir perkelt i sql(reikia naudot package manager console ir naudoti migracijas (Add-Migration)
    }
}
