using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            double startSalary = double.Parse(Console.ReadLine());
            double monthExpenses = double.Parse(Console.ReadLine());
            double salaryIncrease = double.Parse(Console.ReadLine());
            double carPrice = double.Parse(Console.ReadLine());
            double savingMonths = double.Parse(Console.ReadLine());

            double earned = startSalary;
            double spent = monthExpenses * savingMonths;


            for (double i = 1;  i < savingMonths - 1; i++)
            {
                earned += startSalary + salaryIncrease;
                salaryIncrease += salaryIncrease ;
            }
          

            if (earned - spent >= carPrice)
            {
                Console.WriteLine("Have a nice ride!");
            }
            else
            {
                Console.WriteLine("Work harder!");

            }
        }
    }
}
