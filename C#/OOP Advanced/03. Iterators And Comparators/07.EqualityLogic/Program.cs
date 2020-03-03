using System;
using System.Collections.Generic;

namespace _06.StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sorted = new SortedSet<Person>();
            HashSet<Person> hash = new HashSet<Person>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                int age = int.Parse(inputArgs[1]);

                Person person = new Person(inputArgs[0], age);

                sorted.Add(person);
                hash.Add(person);
            }

            Console.WriteLine(sorted.Count);
            Console.WriteLine(hash.Count);
        }
    }
}
