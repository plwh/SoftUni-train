using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            
            var filters = new List<string>();

            Func<string, string, string, bool> checker = (person, criteria, argument) =>
            {
                switch (criteria)
                {
                    case "Starts with":
                        if (person.StartsWith(argument)) return true;
                        break;
                    case "Ends with":
                        if (person.EndsWith(argument)) return true;
                        break;
                    case "Length":
                        if (person.Length == int.Parse(argument)) return true;
                        break;
                    case "Contains":
                        if (person.Contains(argument)) return true;
                        break;
                }
                return false;
            };

            string line = Console.ReadLine();

            while (line != "Print")
            {
                var commands = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Add filter")
                {
                    filters.Add($"{commands[1]},{commands[2]}");
                }
                else if(commands[0] == "Remove filter")
                {
                    filters.Remove($"{commands[1]},{commands[2]}");
                }

                line = Console.ReadLine();
            }

            foreach (string filter in filters)
            {
                var filterData = filter.Split(',').ToList();
                var criteria = filterData[0];
                var argument = filterData[1];

                people = people.Where(p => !checker(p, criteria, argument)).ToList();
            }

            if (people.Any())
            {
                Console.WriteLine(string.Join(" ", people));
            }
        }
    }
}
