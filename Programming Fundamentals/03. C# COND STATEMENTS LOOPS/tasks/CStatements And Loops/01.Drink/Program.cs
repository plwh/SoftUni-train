using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Drink
{
    class Program
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            string drink = "";

            switch (profession)
            {
                case "Athlete":
                    drink = "Water";
                    break;

                case "Businessman":
                case "Businesswoman":
                    drink = "Coffee";
                    break;

                case "SoftUni Student":
                    drink = "Beer";
                    break;

                default:
                    drink = "Tea";
                    break;
            }

            Console.WriteLine(drink);
        }
    }
}
