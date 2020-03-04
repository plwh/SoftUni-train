using P02_DatabaseFirst.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P12_IncreaseSalaries
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(e => e.Department.Name == "Engineering" ||
                                e.Department.Name == "Tool Design" ||
                                e.Department.Name == "Marketing" ||
                                e.Department.Name == "Information Services")
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName);

                foreach (var emp in employees)
                {
                    emp.Salary += emp.Salary * 0.12m;
                    Console.WriteLine($"{emp.FirstName + " " + emp.LastName} (${emp.Salary:f2})");
                }
                context.SaveChanges();
            }
        }
    }
}
