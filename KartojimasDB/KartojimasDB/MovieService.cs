using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    public class MovieService
    {
        private readonly DbRepository _repository;
        public MovieService()
        { 
        _repository = new DbRepository();
        }
        public void CreateDirector(string firstName, string lastName, DateTime birthDate, DateTime? deathDate = null)
        {
            var director = new Director(firstName, lastName, birthDate, deathDate);
            _repository.AddDirector(director);
            _repository.SaveChanges();
        }
        public List<Director> GetDirectors()
        { 
        return _repository.GetAllDirectorsOrdered();
        }
        public Director GetDirectorById(int id)
        { 
        return _repository.GetDirectorById(id);
        }
        public void AssignGenreToMovie(int movieId, string genre)
        {
            var movie = _repository.GetMovie(movieId);

            if (movie.Genres.Any(g => g.Name.Equals(genre,StringComparison.InvariantCultureIgnoreCase)))
            {
                return;
            }
            var genreFromDb = _repository.GetGenre(genre);
            movie.Genres.Add(genreFromDb ?? new Genre(genre)); // tie klaustukai reiskia kad jeigu bus null tai prides nauja zanra kitaip naudos esama
            _repository.UpdateMovie(movie);
            _repository.SaveChanges();
        }
    }
}
