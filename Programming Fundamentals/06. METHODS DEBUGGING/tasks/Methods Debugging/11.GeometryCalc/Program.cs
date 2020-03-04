using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.GeometryCalc
{
    class Program
    {
        static void CalcArea(double a, double b, bool isTriangle)
        {
            double area = 0;
            if (isTriangle)
            {
                area = (a * b) / 2;
            }
            else
            {
                area = a * b;
            }
            Console.WriteLine($"{area:F2}");
        }

        static void CalcArea(double a, bool isSquare)
        {
            double area = 0;
            if (isSquare)
            {
                area = a * a;
            }
            else
            {
                area = Math.PI * Math.Pow(a, 2);
            }
            Console.WriteLine($"{area:F2}");
        }

        static void Main(string[] args)
        {
            string figType = Console.ReadLine();

            switch (figType)
            {
                case "triangle":
                    double side = double.Parse(Console.ReadLine());
                    double triangleHeight = double.Parse(Console.ReadLine());
                    CalcArea(side, triangleHeight, true);
                    break;
                case "square":
                    double squareSide = double.Parse(Console.ReadLine());
                    CalcArea(squareSide, true);
                    break;
                case "rectangle":
                    double width = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    CalcArea(width, height, false);
                    break;
                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    CalcArea(radius, false);
                    break;
            }
        }
    }
}
