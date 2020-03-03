using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Pet> pets = new List<Pet>();
            List<string> birthdates = new List<string>();

            string line = "";
            while ((line = Console.ReadLine()) != "End")
            {
                string[] tokens = line.Split();

                string name;
                string birthdate;

                switch (tokens[0])
                {
                    case "Citizen":
                        name = tokens[1];
                        int age = int.Parse(tokens[2]);
                        string id = tokens[3];
                        birthdate = tokens[4];

                        citizens.Add(new Citizen(name, age, id, birthdate));
                        birthdates.Add(birthdate);
                        break;
                    case "Pet":
                        name = tokens[1];
                        birthdate = tokens[2];

                        pets.Add(new Pet(name, birthdate));
                        birthdates.Add(birthdate);
                        break;
                }
            }
            

            string year = Console.ReadLine();

            if (ContainsYear(birthdates, year))
            {
                foreach (string birthdate in birthdates)
                {
                    if (birthdate.EndsWith(year))
                    {
                        if (citizens.Any(a => a.Birthdate == birthdate))
                        {
                            Citizen citizen = citizens.Find(a => a.Birthdate == birthdate);
                            Console.WriteLine(citizen.Birthdate);
                        }
                        else if (pets.Any(a => a.Birthdate == birthdate))
                        {
                            Pet pet = pets.Find(a => a.Birthdate == birthdate);
                            Console.WriteLine(pet.Birthdate);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine();
            }
        }

        private static bool ContainsYear(List<string> birthdates, string year)
        {
            foreach (string birthdate in birthdates)
            {
                if (birthdate.EndsWith(year))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
