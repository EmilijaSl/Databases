using Movies;

public static class Program 
{
    public static void Main()
    {
        var moviesService = new MovieService();

        //CreateDirector(); //metodas su user interface tam, kad pridetume rezisieriu i SQL BD
        //PrintAllDirectorsToConsole();
        GetDirectorById();


        void CreateDirector()
        {
            Console.WriteLine("Iveskit varda");
            var firstName = Console.ReadLine();

            Console.WriteLine("Iveskit pavarde");
            var lastName = Console.ReadLine();

            Console.WriteLine("Iveskit gimimo data");
            var birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Iveskit mirimo data");
            var deathDateStr = Console.ReadLine();  
            DateTime? deathDate = string.IsNullOrWhiteSpace(deathDateStr)
                ?null
                : DateTime.Parse(deathDateStr);
            moviesService.CreateDirector(firstName, lastName, birthDate, deathDate);    
        }
        void PrintAllDirectorsToConsole()
        {
            var directors = moviesService.GetDirectors();
            foreach (var director in directors)
            {
                Console.WriteLine($"{director.FirstName}, {director.LastName}, {director.BirthDate}, {director.DeathDate}");
            }
        }
        void GetDirectorById()
        {
            Console.WriteLine("Iveskite id");
            var id = int.Parse(Console.ReadLine());
            var director = moviesService.GetDirectorById(id);
            Console.WriteLine(director.FirstName+" "+director.LastName+" "+director.BirthDate+" "+director.DeathDate);
        }
        void AssigneGenreToMovie()
        {
            Console.WriteLine("iveskite id");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Iveskite zanra");
            var genre = Console.ReadLine();

            moviesService.AssignGenreToMovie(id, genre);
        }

    }
    
}
