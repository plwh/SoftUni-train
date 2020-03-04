using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P09_Employee147
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var employee147 = context.Employees
                    .Skip(146)
                    .Take(1)
                    .Select(e => new {
                        Name = e.FirstName + " " + e.LastName,
                        e.JobTitle,
                        Projects = e.EmployeesProjects
                                    .Select(ep => ep.Project)
                    });

                foreach (var e in employee147)
                {
                    Console.WriteLine($"{e.Name} - {e.JobTitle}");
                    foreach (var p in e.Projects.OrderBy(p => p.Name))
                    {
                        Console.WriteLine($"{p.Name}");
                    }
                }
            }
        }
    }
}
