### Use the CompiledQuery.Compile method to build an expression tree that will not have to be parsed each time the query is executed with new parameters
```csharp

varvar GetEmployees =
    CompiledQuery.Compile((NorthwindLinq2Sql.NorthwindLinq2SqlDataContext nwdc, string ac, string ttl) =>
    from employee in nwdc.Employees
    where employee.HomePhone.Contains(ac) &&
    employee.Title == ttl
    select employee);

var northwindDataContext = new NorthwindLinq2Sql.NorthwindLinq2SqlDataContext();

foreach (var employee in GetEmployees(northwindDataContext, "(206)", "Sales Representative"))
    Console.WriteLine($"{employee.FirstName} {employee.LastName}");

foreach (var employee in GetEmployees(northwindDataContext, "(71)", "Sales Manager"))
    Console.WriteLine($"{employee.FirstName} {employee.LastName}");

```