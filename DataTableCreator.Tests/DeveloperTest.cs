using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTableCreator.Tests
{
    [TestClass]
    public class DeveloperTest
    {
        [TestMethod]
        public void Run()
        {
            var tableCreator = DataTableCreator<Student>.GetCreator();


        }
    }



    public class Student
    {
        public string Id { get; set; }
        public int RNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
    }

}
