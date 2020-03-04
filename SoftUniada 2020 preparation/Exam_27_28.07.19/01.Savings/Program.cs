using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double monthIncome = double.Parse(Console.ReadLine());
            int monthsToSave = int.Parse(Console.ReadLine());
            double sum = double.Parse(Console.ReadLine());

            double savedSum = monthIncome - (sum + (monthIncome * 0.30)); 
            Console.WriteLine("She can save {0:F2}%", (savedSum / monthIncome) * 100);
            Console.WriteLine("{0:F2}",savedSum * monthsToSave);
        }
    }
}
