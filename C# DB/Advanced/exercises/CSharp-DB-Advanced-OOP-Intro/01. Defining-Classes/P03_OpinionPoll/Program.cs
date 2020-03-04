using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_OpinionPoll
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                people.Add(new Person(name, age));
            }

            people
                .Where(a => a.Age > 30)
                .OrderBy(a => a.Name)
                .ToList()
                .ForEach(a => Console.WriteLine(a));
        }
    }
}
