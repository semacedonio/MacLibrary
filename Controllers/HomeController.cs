using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MacLibrary.Models;
using System;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Data;
//using System.Windows.Forms;
//using MySql.Data.dll;

namespace MacLibrary.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    //_logger = logger;
        //}

        public IActionResult Index()
        {

            string connStr = "server=localhost;user=root;database=world;port=3306;password=SeaBassMac@MySQL";
            //string libraryDbString = "server=localhost;user=root;database=library_database;port=3306;password=SeaBassMac@MySQL";

            MySqlConnection conn = new (connStr);
            MySqlConnection conn_library_database = new("server=localhost;user=root;database=library_database;port=3306;password=SeaBassMac@MySQL");

            using (MySqlConnection con = new ("server=localhost;user=root;database=library_database;port=3306;password=SeaBassMac@MySQL"))
            {
                MySqlCommand cmd_library_database = new ("select * from users", con);
            }

            Console.WriteLine("Hello World!");

            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();
                conn_library_database.Open();
                //Perform database operations

                //MySQLCommand Object Tutorial - ExecuteReader
                //String sql = "Select Name, HeadOfState From Country Where Continent = 'Oceania'";
                //MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlDataReader rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                //}
                //rdr.Close();

                //MySQLCommand Object Tutorial - ExecuteNonQuery
                //String sqlInsert = "Insert Into Country (Name, HeadOfState, Continent) Values ('Disneyland', 'Mickey Mouse', 'North America')";
                //MySqlCommand cmdInsert = new (sqlInsert, conn);
                //cmdInsert.ExecuteNonQuery();


                //MySQLCommand Object Tutorial - ExecuteScalar
                String sqlScalar = "SELECT COUNT(*) FROM Country";
                MySqlCommand cmdScalar = new (sqlScalar, conn);
                object result = cmdScalar.ExecuteScalar();

                MySqlCommand cmd_library_database = new("SELECT COUNT(*) FROM users", conn_library_database);
                object dbResult = cmd_library_database.ExecuteScalar();


                if (result != null)
                {
                    int r = Convert.ToInt32(result);
                    Console.WriteLine("Number of countries in the world database is " + r);
                }

                if (dbResult != null)
                {
                    int r = Convert.ToInt32(dbResult);
                    Console.WriteLine("Library Database: " + dbResult);
                }

                //6.1.3 Working with Decoupled Data
                MySqlDataAdapter daCountry;
                string sql = "SELECT Code, Name, HeadOfState FROM country WHERE continent='North America'";
                daCountry = new MySqlDataAdapter(sql, conn);

                MySqlCommandBuilder cb = new(daCountry);

                DataSet dsCountry;

                dsCountry = new DataSet();
                //Filling Data Set
                daCountry.Fill(dsCountry, "Country");
                //dataGridView1.
                //Updating Data Set
                daCountry.Update(dsCountry, "Country");

                Console.WriteLine("dsCountry: " + dsCountry);

                ////6.1.4 Working with parameters
                //string sql = "Select Name, HeadOfState From Country Where Continent = @Continent";

                //MySqlCommand cmd = new (sql, conn);
                //Console.WriteLine("Enter a continent e.g. 'Europe', 'North America' etc.:");
                //string user_input = Console.ReadLine();
                //cmd.Parameters.AddWithValue("@Continent", "North America");
                //MySqlDataReader rdr = cmd.ExecuteReader();
                //while (rdr.Read())
                //{
                //    Console.WriteLine(rdr["Name"] + "---" + rdr["HeadOfState"]);
                //}
                //rdr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Try Again.");
                Console.WriteLine(ex.ToString());
            }

            //Data Set Object
            //DataSet dsCountry;
            //dsCountry = new DataSet();

            conn.Close();
            Console.WriteLine("Done.");

            conn_library_database.Close();
            Console.WriteLine("Done Library Database.");

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
