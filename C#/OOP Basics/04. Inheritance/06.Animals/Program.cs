using System;
using System.Collections.Generic;

namespace _06.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string animalType = "";
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string[] tokens = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                    string name = tokens[0];
                    string gender = tokens[2];
                    int age;
                    if (!int.TryParse(tokens[1], out age))
                    {
                        ThrowEx();
                    }
                    switch (animalType)
                    {
                        case "Dog":
                            animals.Add(new Dog(name, age, gender));
                            break;
                        case "Cat":
                            animals.Add(new Cat(name, age, gender));
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
                catch(Exception ex)
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
