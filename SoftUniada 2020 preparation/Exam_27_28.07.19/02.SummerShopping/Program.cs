using System;

namespace _02.SummerShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            double pricePerTowel = double.Parse(Console.ReadLine());
            int discountPercentage = int.Parse(Console.ReadLine());

            double umbrellaPrice = (pricePerTowel / 3) * 2;
            double slippersPrice = umbrellaPrice * 0.75;
            double bagPrice = (pricePerTowel + slippersPrice) / 3;
            double sum = pricePerTowel + umbrellaPrice + slippersPrice + bagPrice;
            sum -= sum * discountPercentage / 100;

            if (sum <= budget)
            {
                double leftSum = budget - sum;
                Console.WriteLine($"Annie's sum is {sum:F2} lv. She has {leftSum:F2} lv. left.");
            }
            else
            {
                double leftSum = sum - budget;
                Console.WriteLine($"Annie's sum is {sum:F2} lv. She needs {leftSum:F2} lv. more.");
            }
        }
    }
}
