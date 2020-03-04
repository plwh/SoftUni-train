using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Cube
{
    class Program
    {
        static void CalcLength(double side, string parameter)
        {
            double result = 0;

            switch (parameter)
            {
                case "face":
                    result += Math.Sqrt(2 * Math.Pow(side, 2));
                    break;
                case "space":
                    result += Math.Sqrt(3 * Math.Pow(side, 2));
                    break;
                case "volume":
                    result += Math.Pow(side, 3);
                    break;
                case "area":
                    result += 6 * Math.Pow(side, 2);
                    break;
            }

            Console.WriteLine($"{result:F2}");
        }

        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();

            CalcLength(side, parameter);
        }
    }
}
