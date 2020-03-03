using System;

namespace _05.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaTokens = Console.ReadLine().Split();

                string pizzaName = pizzaTokens[1];

                string [] doughTokens = Console.ReadLine().Split();

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
