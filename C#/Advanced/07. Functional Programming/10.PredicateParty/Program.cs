using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine().Split(' ').ToList();

            Func<string, string, string, bool> checker = (person, criteria, argument) =>
             {
                 switch (criteria)
                 {
                     case "StartsWith":
                         if (person.StartsWith(argument)) return true;
                         break;
                     case "EndsWith":
                         if (person.EndsWith(argument)) return true;
                         break;
                     case "Length":
                         if (person.Length == int.Parse(argument)) return true;
                         break;
                 }
                 return false;
             };

            var line = Console.ReadLine();

            while (line != "Party!")
            {
                var input = line.Split().ToArray();

                var action = input[0];
                var criteria = input[1];
                var argument = input[2];

                var filteredPeople = new List<string>();
                foreach (string person in people)
                {
                    if (checker(person, criteria, argument))
                    {
                        switch (action)
                        {
                            case "Double":
                                for (int j = 0; j < 2; j++) filteredPeople.Add(person);
                                break;
                            case "Remove":
                                break;
                        }
                    }
                    else
                    {
                        filteredPeople.Add(person);
                    }
                }

                people = filteredPeople.ToList();
                line = Console.ReadLine();
            }

            if (people.Count > 0)
            {
                Console.WriteLine(String.Join(", ", people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
