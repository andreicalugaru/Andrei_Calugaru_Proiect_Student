using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stud_Proj;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ConnectionManager conn = new ConnectionManager();
            Student stud = new Student();
            conn.RemoveStudent(-1);
            stud.IdStudent = -1;
            conn.AddStudent(stud);
            Assert.IsTrue(conn.FindStudent(-1));
            conn.RemoveStudent(-1);


        }
    }
}
