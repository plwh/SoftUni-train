using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P04_EmployeesSalaryOver50K
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var employeeNames = context.Employees
                    .Where(e => e.Salary > 50000)
                    .OrderBy(e => e.FirstName)
                    .Select(e => e.FirstName);

                foreach (var name in employeeNames)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
