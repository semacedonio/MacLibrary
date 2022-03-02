using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MacLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

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

            using (MySqlConnection con = new ("server=localhost;user=root;database=library_database;port=3306;password=SeaBassMac@MySQL"))
            {
                MySqlCommand cmd = new ("select * from users", con);
            }

            Console.WriteLine("Hello World!");

            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();
                //Perform database operations

                //String sql = "Select Name, HeadOfState From Country Where Continent = 'Oceania'";
                //MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlDataReader rdr = cmd.ExecuteReader();

                //String sqlInsert = "Insert Into Country (Name, HeadOfState, Continent) Values ('Disneyland', 'Mickey Mouse', 'North America')";
                //MySqlCommand cmdInsert = new (sqlInsert, conn);
                //cmdInsert.ExecuteNonQuery();

                String sqlScalar = "SELECT COUNT(*) FROM Country";
                MySqlCommand cmdScalar = new (sqlScalar, conn);
                object result = cmdScalar.ExecuteScalar();
                if(result != null)
                {
                    int r = Convert.ToInt32(result);
                    Console.WriteLine("Number of countries in the world database is " + r);
                }

                //while (rdr.Read())
                //{
                //    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
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
