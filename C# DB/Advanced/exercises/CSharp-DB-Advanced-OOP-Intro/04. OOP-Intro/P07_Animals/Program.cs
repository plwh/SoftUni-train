using System;
using System.Collections.Generic;

namespace P07_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input = "";

            while ((input = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string animalType = input;

                    string[] tokens = Console.ReadLine().Split();

                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string gender = tokens[2];

                    if (!int.TryParse(tokens[1], out age))
                    {
                        ThrowEx();
                    }

                    switch (animalType)
                    {
                        case "Cat":
                            animals.Add(new Cat(name, age, gender));
                            break;
                        case "Dog":
                            animals.Add(new Dog(name, age, gender));
                            break;
                        case "Frog":
                            animals.Add(new Frog(name, age, gender));
                            break;
                        case "Kitten":
                            animals.Add(new Kitten(name, age));
                            break;
                        case "Tomcat":
                            animals.Add(new Tomcat(name, age));
                            break;
                        default:
                            ThrowEx();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
                animal.ProduceSound();
            }
        }

        public static ArgumentException ThrowEx()
        {
            throw new ArgumentException("Invalid input!");
        }
    }
}
