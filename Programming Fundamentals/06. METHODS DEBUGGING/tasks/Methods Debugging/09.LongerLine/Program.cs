using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.LongerLine
{
    class Program
    {
        static void CalcClosetPoint(double x1, double y1, double x2, double y2)
        {
            double firstPoint = Math.Sqrt(Math.Pow(y1, 2) + Math.Pow(x1, 2));
            double secondPoint = Math.Sqrt(Math.Pow(y2, 2) + Math.Pow(x2, 2));

            if (firstPoint <= secondPoint)
            {
                Console.WriteLine("({0}, {1})({2}, {3})", x1, y1, x2, y2);
            }
            else
            {
                Console.WriteLine("({0}, {1})({2}, {3})", x2, y2, x1, y1);
            }
        }


        static void Main(string[] args)
        {
            double firstPointX = double.Parse(Console.ReadLine());
            double firstPointY = double.Parse(Console.ReadLine());
            double secondPointX = double.Parse(Console.ReadLine());
            double secondPointY = double.Parse(Console.ReadLine());
            double thirdPointX = double.Parse(Console.ReadLine());
            double thirdPointY = double.Parse(Console.ReadLine());
            double fourthPointX = double.Parse(Console.ReadLine());
            double fourthPointY = double.Parse(Console.ReadLine());

            double firstLineLength = Math.Sqrt(Math.Pow((secondPointY - firstPointY), 2) + Math.Pow((secondPointX - firstPointX), 2));
            double secondLineLength = Math.Sqrt(Math.Pow((fourthPointY - thirdPointY), 2) + Math.Pow((fourthPointX - thirdPointX), 2));

            if (firstLineLength > secondLineLength)
            {
                CalcClosetPoint(firstPointX, firstPointY, secondPointX, secondPointY);
            }
            else
            {
                CalcClosetPoint(thirdPointX, thirdPointY, fourthPointX, fourthPointY);
            }
        }
    }
}
