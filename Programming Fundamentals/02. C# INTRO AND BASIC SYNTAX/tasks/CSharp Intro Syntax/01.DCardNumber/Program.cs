using System;

namespace _01.DCardNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string r = "";

            for (int i = 0; i < 4; i++)
            {
                r += String.Format("{0:D4} ", int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(r.TrimEnd());
        }
    }
}
