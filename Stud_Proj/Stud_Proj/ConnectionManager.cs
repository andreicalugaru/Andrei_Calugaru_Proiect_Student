using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stud_Proj
{
    class ConnectionManager
    {
        string connectionSettings;

        public ConnectionManager()
        {
            connectionSettings = @"server=127.0.0.1;port=3306;userid=root;password=;database=studentsdb";
        }

        public void GetName(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionSettings))
            {
                connection.Open();
                string statement = "SELECT Nume FROM student WHERE idStudent=1";
                MySqlCommand cmd = new MySqlCommand(statement, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                //if (reader.HasRows)
                //{
                //    while(reader.Read())
                //   {
                //       string nume = reader.GetString("Nume");
                //       Console.WriteLine(nume);
                //   }
                // }
                reader.Read();
                Console.WriteLine(reader.GetString("Nume"));

            }
        }
    }


}
