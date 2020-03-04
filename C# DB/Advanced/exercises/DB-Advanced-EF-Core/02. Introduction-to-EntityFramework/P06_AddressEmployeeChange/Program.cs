using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System;
using System.Linq;

namespace P06_AddressEmployeeChange
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var address = new Address()
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

                Employee employee = context.Employees.First(e => e.LastName == "Nakov");
                employee.Address = address;
                context.SaveChanges();

                var adresses = context.Employees
                    .OrderByDescending(e => e.AddressId)
                    .Take(10)
                    .Select(e => e.Address.AddressText);

                foreach (var addressInfo in adresses)
                {
                    Console.WriteLine(addressInfo);
                }
            }
        }
    }
}
