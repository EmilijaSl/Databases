using Dapper;
using Dapper_leson_11;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Kokia knyga rasti?");
var bookName = Console.ReadLine();

var result = DatabaseRepository.GetBooksBySPTask<Book>(bookName);
foreach (var item in result)
{
    Console.WriteLine(item.Name);
}



//void GetBooksByStoredProcedure(string bookName) //pasiiimti info naudojant parametra
//{
//    //var sql = "EXECUTE getBooks @book_name";
//    var procedure = "GETBOOKS";
//    var connectionString = $"Server=localhost;Database=KnygosDb;Trusted_Connection=True;";

//    using var connection = new SqlConnection(connectionString);
//    connection.Open();

//    var sqlParams = new { book_name = bookName };
//    var result = connection.Query<Book>(procedure,sqlParams,commandType: CommandType.StoredProcedure);

//    if (result.Any())
//    {

//        foreach (var item in result)
//        {
//            Console.WriteLine($"{item.Name} va va va ");
//        }
//    }
//    else
//    {
//        Console.WriteLine("Nera tokios");
//    }

//}

//void GetBooks(string bookName)
//{
//    var sql = $"SELECT * from Books WHERE Name like '@book_name'";
//    var connectionString = $"Server=localhost;Database=KnygosDb;Trusted_Connection=True;";

//    using var connection = new SqlConnection(connectionString);
//    connection.Open();

//    var sqlParams = new { book_name = bookName }; //sita dalis apsaugo nuo nuhackinimo/bugo. tiesiogine userio ivesti paverciam patrametru
//    var result = connection.Query<Book>(sql);

//    if (result.Any())
//    {

//        foreach (var item in result)
//        {
//            Console.WriteLine($"{item.Name} va va va ");
//        }
//    }
//    else
//    {
//        Console.WriteLine("Nera tokios");
//    }
//}