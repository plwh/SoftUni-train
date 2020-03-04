using System;

namespace P02_DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            DateModifier modifier = new DateModifier();

            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            double dayDifference = modifier.GetDateDifference(date1, date2);
            Console.WriteLine(dayDifference);
        }
    }
}
