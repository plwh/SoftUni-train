using System;
using System.Globalization;

namespace _01.LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;


            double lemonsWeight = double.Parse(Console.ReadLine());
            double sugarWeight = double.Parse(Console.ReadLine());
            double waterWeight = double.Parse(Console.ReadLine());

            double lemonJuice = lemonsWeight * 980;
            double lemonade = lemonJuice + waterWeight * 1000 + (sugarWeight * 0.30);

            double soldCups = Math.Floor(lemonade / 150);
            double sum = soldCups * 1.20;

            Console.WriteLine("All cups sold: " + soldCups);
            Console.WriteLine("Money earned: {0:F2}", sum);
        }
    }
}
