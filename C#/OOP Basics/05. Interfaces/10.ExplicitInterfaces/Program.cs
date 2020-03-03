using System;

namespace _10.ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "";
            while ((line = Console.ReadLine()) != "End")
            {
                string[] tokens = line.Split();

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson person = citizen;

                person.GetName();

                IResident resident = citizen;

                resident.GetName();
            }
        }
    }
}
