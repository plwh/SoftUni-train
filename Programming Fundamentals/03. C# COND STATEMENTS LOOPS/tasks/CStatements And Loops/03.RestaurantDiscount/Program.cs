using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RestaurantDiscount
{
    class Program
    {
        static double ApplyDiscount(string package, double initialPrice)
        {
            double discount = 0;
            switch (package)
            {
                case "Normal":
                    initialPrice += 500;
                    discount = 0.05 * initialPrice;
                    break;
                case "Gold":
                    initialPrice += 750;
                    discount = 0.10 * initialPrice;
                    break;
                case "Platinum":
                    initialPrice += 1000;
                    discount = 0.15 * initialPrice;
                    break;
            }
            return initialPrice - discount;
        }

        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();
            double price = 0;
            string hall = "";
            bool isAppropriateHall = true;

            if (groupSize <= 50)
            {
                hall = "Small Hall";
                price = 2500;
            }
            else if (groupSize > 50 && groupSize <= 100)
            {
                hall = "Terrace";
                price = 5000;
            }
            else if (groupSize > 100 && groupSize <= 120)
            {
                hall = "Great Hall";
                price = 7500;
            }
            else
            {
                isAppropriateHall = false;
            }

            if (isAppropriateHall)
            {
                price = ApplyDiscount(package, price);

                Console.WriteLine("We can offer you the {0}", hall);
                Console.WriteLine("The price per person is {0:F2}$", price / groupSize);
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
        }
    }
}
