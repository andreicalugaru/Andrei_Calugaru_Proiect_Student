using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stud_Proj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionManager cm = new ConnectionManager();

                dataGridView1.DataSource = cm.GetStudents();
            }
            catch(Exception except)
            {
                MessageBox.Show(except.Message);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student();
                student.IdStudent = Convert.ToInt32(textBoxId.Text);
                student.FirstName = textBoxFirstName.Text;
                student.LastName = textBoxLastName.Text;
                student.BirthDate = datePick.Value;
                student.Address = textBoxAddress.Text;
                ConnectionManager conn = new ConnectionManager();
                conn.AddStudent(student);
            }
            catch(Exception except)
            {
                MessageBox.Show(except.Message);
            }

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student();
                student.IdStudent = Convert.ToInt32(textBoxId.Text);
                student.FirstName = textBoxFirstName.Text;
                student.LastName = textBoxLastName.Text;
                student.BirthDate = datePick.Value;
                student.Address = textBoxAddress.Text;
                ConnectionManager conn = new ConnectionManager();
                conn.UpdateStudent(student);
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionManager conn = new ConnectionManager();
                conn.RemoveStudent(Convert.ToInt32(textBoxId.Text));
            }
            catch(Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }
    }
}
