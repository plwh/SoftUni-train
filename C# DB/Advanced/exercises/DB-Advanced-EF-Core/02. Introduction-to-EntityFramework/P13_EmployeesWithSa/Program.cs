using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P13_EmployeesWithSa
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var selectedEmployees = context.Employees
                    .Where(e => e.FirstName.Substring(0, 2) == "Sa")
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName);


                foreach (var emp in selectedEmployees)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:f2})");
                }
            }
        }
    }
}
