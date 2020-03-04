using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentDatabaseInitializer.Generators.Course
{
    public class PriceGenerator
    {
        public static double GeneratePrice()
        {
            Random rnd = new Random();

            string number = $"{rnd.Next(1,1000)}.{rnd.Next(1, 99)}";

            return double.Parse(number);
        }
    }
}
