using System;
using System.Reflection;

namespace P01_OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            Family family = new Family();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                family.AddMember(new Person(tokens[0], int.Parse(tokens[1])));
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
