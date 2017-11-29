using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataTableCreator.Attributes;

namespace DataTableCreator.Tests
{
    [TestClass]
    public class DeveloperTest
    {
        [TestMethod]
        public void Run()
        {
            var tableCreator = DataTableCreator<Student>.GetCreator();
            
            var student = new Student
            {
                Id = "1",
                Address = "asdsad",
                RNo= 1,
                FirstName = "Bharat",
                LastName = "Ku",
                DOB = DateTime.Now.AddYears(-23).Date
            };

            tableCreator
                .Add(student)
                .Add(student)
                .Add(student)
                .Add(student)
                .Add(student)
                .Add(student)
                .AddRange(new []
                {
                    student,
                    student
                });
            
            var dt = tableCreator.GetDataTable();
        }
    }



    public class Student
    {
        public string Id { get; set; }

        [DataColumnName("RollNumber")]
        public int RNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
    }

}
