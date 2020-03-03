using System;

namespace _03.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family1 = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();

                string personName = personInfo[0];
                int personAge = int.Parse(personInfo[1]);

                Person personToAdd = new Person(personName,personAge);

                family1.AddMember(personToAdd);
            }

            Console.WriteLine(family1.GetOldestMember());
        }
    }
}
