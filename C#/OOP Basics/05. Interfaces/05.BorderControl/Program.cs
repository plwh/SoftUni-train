using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Robot> robots = new List<Robot>();
            List<string> ids = new List<string>();

            string line = "";
            while ((line = Console.ReadLine()) != "End")
            {
                string[] tokens = line.Split();

                string name;
                string id;

                if (tokens.Length == 3)
                {
                    name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    id = tokens[2];
                    citizens.Add(new Citizen(name, age, id));
                    ids.Add(id);
                }
                else if (tokens.Length == 2)
                {
                    name = tokens[0];
                    id = tokens[1];
                    robots.Add(new Robot(name, id));
                    ids.Add(id);
                }
            }

            string fakeId = Console.ReadLine();

            foreach (string id in ids)
            {
                if (id.EndsWith(fakeId))
                {
                    if (citizens.Any(a => a.Id == id))
                    {
                        Citizen citizen = citizens.Find(a => a.Id == id);
                        Console.WriteLine(citizen.Id);
                    }
                    else if (robots.Any(a => a.Id == id))
                    {
                        Robot robot = robots.Find(a => a.Id == id);
                        Console.WriteLine(robot.Id);
                    }
                }
            }
        }
    }
}
