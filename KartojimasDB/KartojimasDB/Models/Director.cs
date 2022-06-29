using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Director
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { set; get; }
        public DateTime BirthDate { set; get; }
        public DateTime? DeathDate { set; get; }  //klaustuka pridejus klase tampa nulable
        public List<Movie> Movies { get; set; }
        private Director()
        { }

        public Director(string firstName, string lastName, DateTime birthDate, DateTime? deathDate)
        {
            
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            DeathDate = deathDate;
            Movies = new List<Movie>();
           
        }   

    }
}
