using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P08_AddressesByTown
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var addresses = context.Addresses
                    .OrderByDescending(a => a.Employees.Select(e => e.AddressId == a.AddressId).Count())
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.AddressText)
                    .Take(10)
                    .Select(a => new {Text = a.AddressText, TownName = a.Town.Name, EmployeesCount = a.Employees.Count} );

                foreach (var item in addresses)
                {
                    Console.WriteLine($"{item.Text}, {item.TownName} - {item.EmployeesCount} employees");
                }
            }
        }
    }
}
