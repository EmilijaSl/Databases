using ManyToManyAFPersistance;
using ManyToManyAFPersistance.Models;
using System.Text;

var repository = new BooksRepository();

var harryPotter = new Book("Harry Potter"); // susikuriam nauja knyga
var lordOfRings = new Book("Lord of the Rings");


var adventuresCategory = new Categories("Adventure");
var fantasyCategory = new Categories("Fantasy"); //sukuriame naujas kategorijas ir prie ju pridedame knygas

adventuresCategory.Books.Add(harryPotter);
fantasyCategory.Books.Add(lordOfRings);
fantasyCategory.Books.Add(harryPotter);

repository.CreatCategory(adventuresCategory);
repository.CreatCategory(fantasyCategory);
repository.SaveChanges();

////pvz value tipo ir reference (pati gerai nesupratau)
//var harryPotter = new Book("Harry Potter");
//var harryPotterCopy = harryPotter;
//harryPotterCopy.Name = "Harry Potter updated name";

//Console.WriteLine(harryPotterCopy.Name);
//Console.WriteLine(harryPotter.Name);

////stringbuilderis jis sujungia belekur tekste issmetytas dalis ir jas kai iskvieti paraso i bendra sakini
//var stringBuilder = new StringBuilder();
//stringBuilder.Append("sakinys ");
//stringBuilder.Append("kratinys ");
//stringBuilder.Append("vivys");

//var myString = stringBuilder.ToString();
//Console.WriteLine(myString);
var books = repository.GetBooksLazily("Rings");
foreach (var book in books) //sita dalis parodo kokiom kategorijom plius priklauso knygos
{
    Console.WriteLine($"{book.Name} categories:");
    foreach (var categories in book.Category)
    {
        Console.WriteLine(categories.Name);
    }
}