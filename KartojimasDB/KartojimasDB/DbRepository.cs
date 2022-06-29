using Microsoft.EntityFrameworkCore;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    public class DbRepository
    {
        private readonly MoviesDbContext _dbContext;
        public DbRepository()
        { 
        _dbContext = new MoviesDbContext();
        }
        public void AddDirector(Director director)
        { 
        _dbContext.Directors.Add(director);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public List<Director> GetAllDirectorsOrdered() //istraukia is DB visus rezisierius ir surusiuoja pagal gimimo metus
        {
            return _dbContext.Directors.OrderBy(x => x.BirthDate).ToList(); //kad butu patogiau ieskoti siulo uzsideti indeksus (antroje pamokoje buvo apie juos destyta
            
        }
        public List<Director> GetAllDead() //is cia metodus persikeliam i miovieservice nes cia readonly, o is ten i program cs
        {
            return _dbContext.Directors.OrderBy(x => x.BirthDate).ToList().Where(y=>y.DeathDate != null).ToList();
        }
        public Director GetDirectorById(int id)
        {
            return _dbContext.Directors.FirstOrDefault(x => x.ID == id);
        }
        public Movie GetMovie(int id)
        {
            return _dbContext.Movies.Include(x => x.Genres).FirstOrDefault(y => y.Id == id); //prie filmu lenteles prijungiam zanrus ir renkam pagal id
        }
        public Genre GetGenre(string genre)
        {
            return _dbContext.Genres.FirstOrDefault(g => g.Name.ToUpper()==genre.ToUpper()); //to upper naudojam kad suvienodintume srifta, ir kad lygintu vienodu sriftu taip isvengsim klaidu
        }
        public void UpdateMovie(Movie movie)
        { 
        _dbContext.Attach(movie); //attache reiskia kad prijunk filma prie entity framevorko
        }
    }
}
