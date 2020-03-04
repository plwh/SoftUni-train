using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P07_EmployeesProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var empInfo = context.Employees
                    .Where(e => e.EmployeesProjects
                         .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                    .Take(30)
                    .Select(e => new {
                        Name = e.FirstName + " " + e.LastName,
                        ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                        Projects = e.EmployeesProjects
                            .Select(ep => ep.Project)
                    });
                    
                foreach (var emp in empInfo)
                {
                    Console.WriteLine($"{emp.Name} - Manager: {emp.ManagerName}");
                    foreach (var p in emp.Projects)
                    {
                        Console.WriteLine($"{p.Name} {p.StartDate} {((p.EndDate == null)? "not finished" : p.EndDate.ToString())}");
                    }
                }
            }
        }
    }
}
