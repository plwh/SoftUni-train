using System;

namespace P04_PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dough and topping test
            //string input = "";

            //while ((input = Console.ReadLine()) != "END")
            //{
            //    string[] tokens = input.Split();

            //    double weight = 0;

            //    try
            //    {

            //        switch (tokens[0])
            //        {
            //            case "Dough":
            //                string flourType = tokens[1];
            //                string bakingTechnique = tokens[2];
            //                weight = double.Parse(tokens[3]);

            //                Dough dough = new Dough(flourType, bakingTechnique, weight);
            //                Console.WriteLine(string.Format($"{dough.Calories:f2}"));

            //                break;
            //            case "Topping":
            //                string type = tokens[1];
            //                weight = double.Parse(tokens[2]);

            //                Topping topping = new Topping(type, weight);
            //                Console.WriteLine(string.Format($"{topping.Calories:f2}"));
            //                break;
            //        }
            //    }
            //    catch(ArgumentException ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}

            try
            {
                string[] pizzaTokens = Console.ReadLine().Split();

                string pizzaName = pizzaTokens[1];

                string[] doughTokens = Console.ReadLine().Split();

                string flourType = doughTokens[1];
                string bakingTechnique = doughTokens[2];
                int doughWeight = int.Parse(doughTokens[3]);

                Dough dough = new Dough(flourType, bakingTechnique, doughWeight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string command = "";
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingTokens = command.Split();

                    string type = toppingTokens[1];
                    int toppingWeight = int.Parse(toppingTokens[2]);

                    Topping topping = new Topping(type, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
