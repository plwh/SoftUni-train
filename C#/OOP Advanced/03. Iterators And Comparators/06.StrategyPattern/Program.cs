using System;
using System.Collections.Generic;

namespace _06.StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> namePeople = new SortedSet<Person>(new PersonNameComparer());
            SortedSet<Person> agePeople = new SortedSet<Person>(new PersonAgeComparer());

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                int age = int.Parse(inputArgs[1]);

                Person person = new Person(inputArgs[0], age);

                namePeople.Add(person);
                agePeople.Add(person);
            }

            Console.WriteLine(string.Join(Environment.NewLine, namePeople));
            Console.WriteLine(string.Join(Environment.NewLine, agePeople));
        }
    }
}
