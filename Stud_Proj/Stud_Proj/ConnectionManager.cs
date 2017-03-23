using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stud_Proj
{
   public class ConnectionManager
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

        public void AddStudent(Student student)
        {
            using(MySqlConnection connection = new MySqlConnection(connectionSettings))
            {
                connection.Open();
                string statement = "INSERT INTO student(idStudent, FirstName, LastName, BirthDate, Address) VALUES (@idStudent, @FirstName, @LastName, @BirthDate, @Address)";
                MySqlCommand cmd = new MySqlCommand(statement, connection);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idStudent", student.IdStudent);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", student.BirthDate);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionSettings))
            {
                connection.Open();
                string statement = "UPDATE student SET FirstName = @FirstName, LastName = @LastName, BirthDate = @BirthDate, Address = @Address WHERE idStudent = " + student.IdStudent;
                MySqlCommand cmd = new MySqlCommand(statement, connection);
                cmd.Prepare();
                //cmd.Parameters.AddWithValue("@idStudent", student.IdStudent);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@BirthDate", student.BirthDate);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveStudent(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionSettings))
            {
                connection.Open();
                string statement = "DELETE FROM student WHERE idStudent =" + id;
                MySqlCommand cmd = new MySqlCommand(statement, connection);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }

        public bool FindStudent(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionSettings))
            {
                int readid= -1;
                connection.Open();
                string statement = "SELECT * FROM student WHERE idStudent="  + id;
                MySqlCommand cmd = new MySqlCommand(statement, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                //while (reader.Read())
                reader.Read();
                //{
                    readid = reader.GetInt32("idStudent");
                //}
                return readid == id;
            }
        }
    }

    


}
