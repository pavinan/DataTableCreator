# DataTableCreator
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
```
