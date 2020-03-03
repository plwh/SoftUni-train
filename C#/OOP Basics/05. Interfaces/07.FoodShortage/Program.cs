using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string name;
                int age;

                if (tokens.Length == 4)
                {
                    name = tokens[0];
                    age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthdate = tokens[3];

                    if (citizens.Any(a => a.Name == name)) continue;

                    citizens.Add(new Citizen(name, age, id, birthdate));
                }
                else if (tokens.Length == 3)
                {
                    name = tokens[0];
                    age = int.Parse(tokens[1]);
                    string group = tokens[2];

                    if (rebels.Any(a => a.Name == name)) continue;

                    rebels.Add(new Rebel(name, age, group));
                }
            }

            string targetName = "";
            while ((targetName = Console.ReadLine()) != "End")
            {
                if (citizens.Any(a => a.Name == targetName))
                {
                    citizens.Find(a => a.Name == targetName).BuyFood();
                }
                else if (rebels.Any(a => a.Name == targetName))
                {
                    rebels.Find(a => a.Name == targetName).BuyFood();
                }
            }

            Console.WriteLine(citizens.Sum(a => a.Food) + rebels.Sum(a => a.Food));
        }
    }
}
