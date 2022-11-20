using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Drones.Infrastructure.Services
{
    public class Database
    {
        public SQLiteConnection Connection { get; set; }
        public Database()
        {
            Connection = new SQLiteConnection("Data Source=database.sqlite3");
            if (!File.Exists("./database.sqlite3"))
            {
                SQLiteConnection.CreateFile("database.sqlite3");
                Console.WriteLine("Database file created!!!");
            }

        }
    }
}
