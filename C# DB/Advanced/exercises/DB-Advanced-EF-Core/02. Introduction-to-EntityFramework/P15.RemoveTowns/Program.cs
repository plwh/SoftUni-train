using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P15.RemoveTowns
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                string townName = Console.ReadLine();

                // get town id
                int townId = context.Towns
                    .Where(t => t.Name == townName)
                    .Select(t => t.TownId)
                    .First();

                // get addresses to remove based on town id
                var addressesToRemove = context.Addresses
                    .Where(a => a.TownId == townId);

                // get addresses count
                int addressesCount = addressesToRemove.Count();

                foreach (var a in addressesToRemove)
                { 
                    // set town id to null in addresses table
                    a.TownId = null;

                    // find employees which have same address and set it to null
                    foreach (var e in context.Employees.Where(e => e.AddressId == a.AddressId))
                    {
                        e.AddressId = null;
                    }

                    // remove addresses records
                    context.Addresses.Remove(a);
                }

                // remove town record
                var townToRemove = context.Towns.Where(t => t.TownId == townId).First();
                context.Towns.Remove(townToRemove);

                context.SaveChanges();

                // display number of removed addresses

                if (addressesCount == 1)
                {
                    Console.WriteLine($"1 address in {townName} was deleted.");
                }
                else if (addressesCount > 1)
                {
                    Console.WriteLine($"{addressesCount} addresses in {townName} were deleted.");
                }
                else
                {
                    Console.WriteLine("No address deleted.");
                }
            }
        }
    }
}
