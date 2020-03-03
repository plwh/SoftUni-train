using System;
using System.Collections.Generic;

namespace _03.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string line = "";
            while ((line = Console.ReadLine()) != "End")
            {
                string[] animalTokens = line.Split();
                string[] foodTokens = Console.ReadLine().Split();

                Animal animal = ParseAnimalInfo(animalTokens);
                Food food = ParseFoodInfo(foodTokens);

                animals.Add(animal);
                animal.MakeSound();
                try
                {
                    animal.Feed(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food ParseFoodInfo(string[] tokens)
        {
            switch (tokens[0])
            {
                case "Vegetable":
                    return new Vegetable(int.Parse(tokens[1]));
                case "Fruit":
                    return new Fruit(int.Parse(tokens[1]));
                case "Meat":
                    return new Meat(int.Parse(tokens[1]));
                case "Seeds":
                    return new Seeds(int.Parse(tokens[1]));
            }
            return null;
        }

        private static Animal ParseAnimalInfo(string[] tokens)
        {
            switch (tokens[0])
            {
                case "Owl":
                    return new Owl(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                case "Hen":
                    return new Hen(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                case "Mouse":
                    return new Mouse(tokens[1], double.Parse(tokens[2]), tokens[3]);
                case "Dog":
                    return new Dog(tokens[1], double.Parse(tokens[2]), tokens[3]);
                case "Cat":
                    return new Cat(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                case "Tiger":
                    return new Tiger(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
            }
            return null;
        }
    }
}
