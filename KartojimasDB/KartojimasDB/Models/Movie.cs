using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public List<Genre> Genres { get; set; } //cia sarisis kad filmas turi zanrus ir rezisieriu. Daug zanru vienas rez
        public Director Director { get; set; }
        private Movie() //entity framework butinai turi beparametrini konstruktoriu turet
        {
        }
        public Movie(string name, int releaseYear)
        { 
            Name = name;
            ReleaseYear = releaseYear;  
            Genres = new List<Genre>(); //sita eilute padaro, kad filmas susikurtu su turciu zanru listu
        }
    }
}
