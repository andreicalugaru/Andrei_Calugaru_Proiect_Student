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

        public IList<Student> GetStudents()
        {
            IList<Student> studentList = new List<Student>();
            using (MySqlConnection connection = new MySqlConnection(connectionSettings))
            {
               
                connection.Open();
                string statement = "SELECT * FROM student";
                MySqlCommand cmd = new MySqlCommand(statement, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                   while(reader.Read())
                   {
                        Student stud = new Student();
                        stud.IdStudent = reader.GetInt32("idStudent");
                        stud.FirstName = reader.GetString("FirstName");
                        stud.LastName = reader.GetString("LastName");
                        stud.BirthDate = reader.GetDateTime("BirthDate");
                        stud.Address = reader.GetString("Address");
                        studentList.Add(stud);
                    }
                
                }

            }
            return studentList;
        }
    }


}
