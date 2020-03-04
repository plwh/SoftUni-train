using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P10_DepMoreThanFiveEmp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var departments = context.Departments
                    .Where(d => d.Employees.Select(e => e.DepartmentId == d.DepartmentId).Count() > 5)
                    .OrderBy(d => d.Name)
                    .Select(d => new
                    {
                        d.Name,
                        ManagerName = d.Manager.FirstName + " " + d.Manager.LastName,
                        d.Employees
                    });

                foreach (var dep in departments)
                {
                    Console.WriteLine($"{dep.Name} - {dep.ManagerName}");
                    foreach (var emp in dep.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                    {
                        Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                    }
                    Console.WriteLine(new string('-', 10));
                }
            }
        }
    }
}
