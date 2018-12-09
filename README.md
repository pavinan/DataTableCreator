# DataTableCreator
[![Build status](https://ci.appveyor.com/api/projects/status/j375v8i3etemu43u/branch/master?svg=true)](https://ci.appveyor.com/project/pavinan/datatablecreator/branch/master)
[![Build Status](https://pavinan.visualstudio.com/Public/_apis/build/status/pavinan.DataTableCreator)](https://pavinan.visualstudio.com/Public/_build/latest?definitionId=11)

Nuget link [https://www.nuget.org/packages/Bharat.DataTableCreator/](https://www.nuget.org/packages/Bharat.DataTableCreator/)

Creates datatable for a class.

**Simple example**

```csharp
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
    .AddRange(new List<Student>
    {
        student,
        student
    });

var dt = tableCreator.GetDataTable();


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

```
