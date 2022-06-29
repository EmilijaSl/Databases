using Microsoft.EntityFrameworkCore;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
        optionsBuilder.UseSqlServer($"Server=localhost;Database=MoviesDb;Trusted_Connection=True;");
        }
        //sitos eilutes virsuje sukuria prieiga informacijai aprasytai auksciau perkelt i sql (po cia kuriam migracijas)
    }

}
