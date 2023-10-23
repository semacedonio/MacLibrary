using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Text;
using System.Configuration;

using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Replication;



namespace MacLibrary.Models
{
    public class Users
    {
        //MySql.Data libraryDb = new MySql.Data;
        public int Id { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public int phone { get; set; }
        public String email { get; set; }
    }
}
