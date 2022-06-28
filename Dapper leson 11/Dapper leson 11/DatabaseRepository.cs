using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_leson_11
{
    public class DatabaseRepository

    //kas parasyta apacioje yra aptimizuotas uzkomentuoto dalyko variantas ivykdyta uzduotis, gal blogai ja perrasiau
    //refaktorint kad sukurtu klases konstruktoriuje ir ta sql connection priskirti private field'ui klases ir ji panaudoti metode, kur gaun knygas (turi buti nebe static)
    {
        private readonly string SQLConnectionString = $"Server=localhost;Database=KnygosDb;Trusted_Connection=True;"; //fieldas paprastas klases kintamasis kuris laiko savyje reiksme
                                                                                                                      //propertis turi get set 
        private readonly IDbConnection ConnectionSQL; //fieldas kurio rusis yra IDbConnection o pavadinimas ConnectionSQL
        public DatabaseRepository() //Constructorius
        { 
        ConnectionSQL = new SqlConnection(SQLConnectionString); //constructoriuje mes priskiriame reiksme
        }
        public List<T> GetBooksBySPTask<T>(string bookName)
        {
            var procedure = "GETBOOKS";
            ConnectionSQL.Open();
            var sqlParams = new { bookName = bookName };
            return ConnectionSQL.Query<T>(procedure, sqlParams, commandType: CommandType.StoredProcedure).ToList(); 
        }

        //public static List<T> GetBooksBySPTask<T>(string bookName)
        //{
        //    var procedure = "GETBOOKS";
        //    var connectionString = $"Server=localhost;Database=KnygosDb;Trusted_Connection=True;";

        //    using var connection = new SqlConnection(connectionString);
        //    connection.Open();

        //    var sqlParams = new {bookName = bookName};

        //    return connection.Query<T>(procedure, sqlParams, commandType: CommandType.StoredProcedure).ToList();

        //}

        
    }
}
