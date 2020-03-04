using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CenterPoint
{
    class Program
    {
        static void CalcClosetPoint(double x1, double y1, double x2, double y2)
        {
            double firstPoint = Math.Sqrt(Math.Pow(y1, 2) + Math.Pow(x1, 2));
            double secondPoint = Math.Sqrt(Math.Pow(y2, 2) + Math.Pow(x2, 2));

            if (firstPoint < secondPoint)
            {
                Console.WriteLine("({0}, {1})", x1, y1);
            }
            else
            {
                Console.WriteLine("({0}, {1})", x2, y2);
            }
        }

        static void Main(string[] args)
        {
            double firstPointX = double.Parse(Console.ReadLine());
            double firstPointY = double.Parse(Console.ReadLine());
            double secondPointX = double.Parse(Console.ReadLine());
            double secondPointY = double.Parse(Console.ReadLine());

            CalcClosetPoint(firstPointX, firstPointY, secondPointX, secondPointY);
        }
    }
}
