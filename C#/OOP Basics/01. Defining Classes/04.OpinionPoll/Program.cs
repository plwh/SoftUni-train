using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OpinionPoll
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();

                string personName = personInfo[0];
                int personAge = int.Parse(personInfo[1]);

                people.Add(new Person(personName, personAge));
            }

            people
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p => Console.WriteLine(p));

        }
    }
}
