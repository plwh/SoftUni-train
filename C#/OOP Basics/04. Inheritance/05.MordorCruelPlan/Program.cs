using System;
using System.Collections.Generic;

namespace _05.MordorCruelPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Food> foods = new List<Food>();
            FoodFactory foodFactory = new FoodFactory();

            string[] tokens = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string token in tokens)
            {
                foods.Add(foodFactory.CreateFood(token));
            }

            Gandalf gandalf = new Gandalf(foods);

            Console.WriteLine(gandalf);
        }
    }
}
