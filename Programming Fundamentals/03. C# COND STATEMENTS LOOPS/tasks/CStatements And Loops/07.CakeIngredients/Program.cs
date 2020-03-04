using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CakeIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = ""; 
            int ingredientCount = 0;
            bool isPreparing = false;

            while (!isPreparing)
            {
                input = Console.ReadLine();
                if (input == "Bake!")
                {
                    Console.WriteLine("Preparing cake with {0} ingredients.", ingredientCount);
                    isPreparing = true;
                }
                else
                {
                    Console.WriteLine("Adding ingredient {0}.", input);
                    ingredientCount++;
                }
            }
        }
    }
}
