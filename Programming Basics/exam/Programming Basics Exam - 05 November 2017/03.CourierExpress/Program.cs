using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CourierExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            string typeOfService = Console.ReadLine();
            int distance = int.Parse(Console.ReadLine());

            double price = 0.0d;
            double extraCost = 0.0d;
            bool isExpress = typeOfService == "express";

            if(weight < 1)
            {
                price = 0.03 * distance;
                if (isExpress)
                {
                    extraCost = (double)80 / 100 * weight * price;
                    price += extraCost;
                }
            }
            else if (weight >= 1 && weight <= 10)
            {
                price = 0.05 * distance;
                if (isExpress)
                {
                    extraCost = (double)40 / 100 * weight * price;
                    price += extraCost;
                }
            }
            else if (weight >= 11 && weight <= 40)
            {
                price = 0.10 * distance;
                if (isExpress)
                {
                    extraCost = (double)5 / 100 * weight * price;
                    price += extraCost;
                }
            }
            else if (weight >= 41 && weight <= 90)
            {
                price = 0.15 * distance;
                if (isExpress)
                {
                    extraCost = (double)2 / 100 * weight * price;
                    price += extraCost;
                }
            }
            else if (weight >= 91 && weight <= 150)
            {
                price = 0.20 * distance;
                if (isExpress)
                {
                    extraCost = (double)1 / 100 * weight * price;
                    price += extraCost;
                }
            }

            Console.WriteLine("The delivery of your shipment with weight of {0:F3} kg. would cost {1:F2} lv.", weight, price);
        }
    }
}
