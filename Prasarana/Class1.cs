using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace Prasarana
{
    public static class UserSession
    {
        public static int IdAnggota { get; set; }
        public static string NamaAnggota { get; set; }
        public static string Role { get; set; }
    }
}
public class Database
    {
        public static string connectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=perpustakaan2;" +
            "Uid=root;" +
            "Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }


namespace Prasarana
{
    internal class Class1
    {
    }
}
